namespace UniGame.Ecs.Proto.GameEffects.FreezeEffect.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Add a freeze effect to the target
    /// </summary>

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public class ApplyFreezeEffectSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private ProtoPool<FreezeTargetEffectComponent> _freezeTargetEffectPool;
        private ProtoPool<ApplyFreezeTargetEffectRequest> _applyFreezeEffectRequestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<ApplyFreezeTargetEffectRequest>()
                .End();
            _freezeTargetEffectPool = _world.GetPool<FreezeTargetEffectComponent>();
            _applyFreezeEffectRequestPool = _world.GetPool<ApplyFreezeTargetEffectRequest>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var applyFreezeEffectRequest = ref _applyFreezeEffectRequestPool.Get(entity);
                if (!applyFreezeEffectRequest.Destination.Unpack(_world, out var target))
                    continue;
                //TODO: duplicate add component
                ref var freezeTargetComponent = ref _freezeTargetEffectPool.GetOrAddComponent(target);
                freezeTargetComponent.DumpTime = applyFreezeEffectRequest.DumpTime;
                freezeTargetComponent.Source = applyFreezeEffectRequest.Source;
            }
        }
    }
}