namespace UniGame.Ecs.Proto.Ability.SubFeatures.ComeToTarget.Systems
{
    using System;
    using Components;
    using Game.Ecs.Core.Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Movement.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class RevokeUpdateComePointByMovementSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<UpdateComePointComponent> _updatePool;
        private ProtoPool<OwnerComponent> _ownerPool;
        private ProtoPool<DeferredAbilityComponent> _deferredPool;
        private ProtoPool<RevokeComeToEndOfRequest> _requestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<UpdateComePointComponent>()
                .Inc<OwnerComponent>()
                .End();
            
            _updatePool = _world.GetPool<UpdateComePointComponent>();
            _ownerPool = _world.GetPool<OwnerComponent>();
            _deferredPool = _world.GetPool<DeferredAbilityComponent>();
            _requestPool = _world.GetPool<RevokeComeToEndOfRequest>();
        }
        
        public void Run()
        {
            

            foreach (var entity in _filter)
            {
                ref var owner = ref _ownerPool.Get(entity);
                if(!owner.Value.Unpack(_world, out var ownerEntity))
                    continue;
   
                _deferredPool.Del(entity);
                _updatePool.Del(entity);

                if (!_requestPool.Has(ownerEntity))
                    _requestPool.Add(ownerEntity);
            }
        }
    }
}