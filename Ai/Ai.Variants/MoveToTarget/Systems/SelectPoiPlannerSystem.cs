namespace UniGame.Ecs.Proto.GameAi.MoveToTarget.Systems
{
    using System;
    using Data;
    using Components;
    using Game.Code.GameLayers.Category;
    using Game.Ecs.Core.Death.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.Ecs.Proto.GameLayers.Category.Components;
    using UniGame.Ecs.Proto.GameLayers.Layer.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.Mathematics;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class SelectPoiPlannerSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private EcsFilter _poiFilter;
        private ProtoPool<MoveByPoiComponent> _dataPool;
        private ProtoPool<MoveToPoiComponent> _poiPool;
        private ProtoPool<MoveToPoiGoalsComponent> _goalsPool;
        private ProtoPool<MoveToGoalComponent> _moveGoalPool;
        private ProtoPool<TransformPositionComponent> _transformPool;
        private ProtoPool<CategoryIdComponent> _categoryPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<MoveByPoiComponent>()
                .Inc<MoveToTargetPlannerComponent>()
                .Inc<MoveToPoiGoalsComponent>()
                .Inc<MoveToGoalComponent>()
                .Inc<TransformPositionComponent>()
                .Inc<LayerIdComponent>()
                .Inc<CategoryIdComponent>()
                .Exc<DisabledComponent>()
                .End();
            
            _poiFilter = _world
                .Filter<MoveToPoiComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var dataComponent = ref _dataPool.Get(entity);
                ref var categoryComponent = ref _categoryPool.Get(entity);
                ref var goalsComponent = ref _goalsPool.Get(entity);
                ref var transformComponent = ref _transformPool.Get(entity);
                ref var goals = ref _moveGoalPool.Get(entity);

                //Если уже есть найденные цели, то POI игнорируются
                var goalsTargets = goals.Goals;
                if (goalsTargets.Count > 0)
                    continue;

                var sqrRange = dataComponent.ReachRange * dataComponent.ReachRange;
                var position = transformComponent.Position;
                var poiGoals = goalsComponent.GoalsLinks;
                var minDistance = float.MaxValue;
                var targetEntity = entity.GetInvalidEntity();
                var targetGoal = new MoveToGoalData();

                foreach (var key in _poiFilter)
                {
                    var poiComponent = _poiPool.Get(key);

                    if (poiComponent.Priority < 0)
                        continue;

                    var complete = false;
                    if (poiGoals.TryGetValue(key, out var value))
                        complete = value.Complete;

                    if (complete) continue;

                    var targetCategory = poiComponent.CategoryId;
                    if (!targetCategory.HasFlag(categoryComponent.Value)) continue;

                    var targetPosition = poiComponent.Position;
                    var distance = math.distancesq(position, targetPosition);
                    
                    if (distance >= minDistance) continue;

                    minDistance = distance;
                    targetEntity = key;

                    value.Complete = distance < sqrRange;
                    value.Position = targetPosition;
                    value.Priority = poiComponent.Priority;
                    value.Target = _world.PackEntity(key);

                    targetGoal = value;
                    poiGoals[key] = targetGoal;
                }

                if ((int)targetEntity < 0) continue;

                goals.Goals.Add(targetGoal);
            }
        }
    }
}