namespace UniGame.Ecs.Proto.GameAi.MoveToTarget.Systems
{
    using System;
    using Ability.Tools;
    using AI.Abstract;
    using AI.Components;
    using Components;
    using Effects;
    using Game.Ecs.Core.Death.Components;
    using Gameplay.LevelProgress.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Movement.Components;
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
    public class MoveToTargetAiSystem : IAiActionSystem,IProtoInitSystem
    {
        public float minSqrDistance = 4f;
        
        private EcsFilter _filter;
        private ProtoWorld _world;
        private AbilityTools _abilityTools;
        
        private ProtoPool<TransformPositionComponent> _transformPool;
        private ProtoPool<TransformDirectionComponent> _directionPool;
        private ProtoPool<MoveToTargetActionComponent> _moveToTargetPool;
        private ProtoPool<MovementPointSelfRequest> _movementPointPool;
        private ProtoPool<RotateToPointSelfRequest> _rotateToPointPool;
        private ProtoPool<ActiveGameViewComponent> _viewPool;
        private ProtoPool<NavMeshAgentComponent> _agentPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _abilityTools = _world.GetGlobal<AbilityTools>();
            
            _filter = _world
                .Filter<MoveToTargetActionComponent>()
                .Inc<TransformComponent>()
                .Inc<AiAgentComponent>()
                .Exc<ImmobilityComponent>()
                .Exc<DisabledComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var moveToTargetComponent = ref _moveToTargetPool.Get(entity);
                ref var directionComponent = ref _directionPool.Get(entity);
                ref var transformComponent = ref _transformPool.Get(entity);
                ref var targetComponentRequest = ref _movementPointPool.GetOrAddComponent(entity);
                
                var position = transformComponent.Position;
                var targetPosition = moveToTargetComponent.Position;
                var sqrDistance = math.distancesq(targetPosition,position);
                
                ref var destination = ref moveToTargetComponent.Position;
                ref var rotateToPoint = ref _rotateToPointPool.GetOrAddComponent(entity);
                rotateToPoint.Point = destination;
                
                if(_viewPool.Has(entity))
                    rotateToPoint.Point = directionComponent.Forward + position;
                
                if (sqrDistance < minSqrDistance)
                {
                    _world.AddComponent<MovementStopSelfRequest>(entity);
                    continue;
                }
                
                targetComponentRequest.Value = destination;
                var packedEntity = _world.PackEntity(entity);
                moveToTargetComponent.Effects.CreateRequests(_world,packedEntity,packedEntity);
            }
        }
    }
}
