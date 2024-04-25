namespace unigame.ecs.proto.GameAi.MoveToTarget.Systems
{
    using System;
    using Components;
    using Data;
    using Game.Ecs.Core.Death.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
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
    public class SelectOutOfRangePlannerSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<MoveByRangeComponent>()
                .Inc<MoveToTargetPlannerComponent>()
                .Inc<TransformPositionComponent>()
                .Inc<MoveToGoalComponent>()
                .Inc<MoveOutOfRangeComponent>()
                .Exc<DisabledComponent>()
                .End();
        }
        
        public void Run()
        {
            var transformPool = _world.GetPool<TransformPositionComponent>();
            var rangePool = _world.GetPool<MoveByRangeComponent>();
            var goalPool = _world.GetPool<MoveToGoalComponent>();
            var outOfRangePool = _world.GetPool<MoveOutOfRangeComponent>();

            foreach (var entity in _filter)
            {
                ref var component = ref goalPool.Get(entity);
                ref var rangeComponent = ref rangePool.Get(entity);
                ref var transformComponent = ref transformPool.Get(entity);

                
                var center = rangeComponent.Center;
                
                var value = new MoveToGoalData
                {
                    Complete = false,
                    Position = center,
                    Priority = rangeComponent.Priority,
                    Target = _world.PackEntity(entity),
                    Effects = rangeComponent.Effects
                };
            
                component.Goals.Add(value);
                
                var minDistance = rangeComponent.MinDistance * rangeComponent.MinDistance;
                var distance = math.distancesq(transformComponent.Position, center);

                if (distance < minDistance) outOfRangePool.Del(entity);
            }
        }
    }
}