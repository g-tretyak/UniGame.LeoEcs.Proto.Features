namespace UniGame.Ecs.Proto.Characteristics.Cooldown.Systems
{
    using System;
    using Base.Components.Events;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    [Serializable]
    public sealed class ResetCooldownSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<BaseCooldownComponent> _baseCooldownPool;
        private ProtoPool<RecalculateCooldownSelfRequest> _requestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<BaseCooldownComponent>()
                .Inc<ResetCharacteristicsEvent>()
                .End();
            
           _baseCooldownPool = _world.GetPool<BaseCooldownComponent>();
           _requestPool = _world.GetPool<RecalculateCooldownSelfRequest>();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var baseCooldown = ref _baseCooldownPool.Get(entity);
                baseCooldown.Modifications.Clear();
                
                if (!_requestPool.Has(entity))
                    _requestPool.Add(entity);
            }
        }
    }
}