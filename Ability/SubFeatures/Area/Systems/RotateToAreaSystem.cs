namespace unigame.ecs.proto.Ability.SubFeatures.Area.Systems
{
    using System;
    using Aspects;
    using Common.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Movement.Components;
    using Target.Aspects;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class RotateToAreaSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private AreaAspect _areaAspect;
        private TargetAbilityAspect _aspect;
        
        private ProtoPool<RotateToPointSelfRequest> _rotateRequestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<AreableAbilityComponent>()
                .Inc<OwnerComponent>()
                .Inc<AbilityValidationSelfRequest>()
                .Inc<AreaLocalPositionComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var owner = ref _areaAspect.Owner.Get(entity);
                
                if (!owner.Value.Unpack(_world, out var ownerEntity)) continue;
                if(!_areaAspect.CanLookAtPool.Has(ownerEntity)) continue;

                ref var ownerTransform = ref _areaAspect.Position.Get(ownerEntity);
                var ownerPosition = ownerTransform.Position;
                ref var areaPosition = ref _areaAspect.AreaPosition.Get(entity);

                ref var request = ref _aspect.RotateTo.GetOrAddComponent(ownerEntity);
                request.Point = ownerPosition + areaPosition.Value;
            }
        }
    }
}