namespace UniGame.Ecs.Proto.GameEffects.FreezeEffect.Systems
{
    using Components;
    using Effects.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Create a request to use the freeze effect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    public class CreateFreezeEffectSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private ProtoPool<EffectComponent> _effectPool;
        private ProtoPool<ApplyFreezeTargetEffectRequest> _applyFreezeEffectRequestPool;
        private ProtoPool<EffectDurationComponent> _effectDurationPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world.Filter<EffectComponent>()
                .Inc<ApplyEffectSelfRequest>()
                .Inc<FreezeEffectComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var effectComponent = ref _effectPool.Get(entity);
                ref var effectDurationComponent = ref _effectDurationPool.Get(entity);
                ref var freezeRequest = ref _applyFreezeEffectRequestPool.Add(_world.NewEntity());
                freezeRequest.Source = effectComponent.Source;
                freezeRequest.Destination = effectComponent.Destination;
                freezeRequest.DumpTime = effectDurationComponent.CreatingTime + effectDurationComponent.Duration;
            }
        }
    }
}