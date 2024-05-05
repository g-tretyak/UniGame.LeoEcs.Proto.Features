namespace UniGame.Ecs.Proto.GameEffects.FreezeEffect.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Remove freeze effect
    /// </summary>

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public class RemoveFreezeEffectSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private ProtoPool<RemoveFreezeTargetEffectRequest> _removeFreezeTargetEffectPool;
        private ProtoPool<FreezeTargetEffectComponent> _freezeTargetEffectPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<RemoveFreezeTargetEffectRequest>().End();
            _removeFreezeTargetEffectPool = _world.GetPool<RemoveFreezeTargetEffectRequest>();
            _freezeTargetEffectPool = _world.GetPool<FreezeTargetEffectComponent>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var removeFreezeTargetEffectRequest = ref _removeFreezeTargetEffectPool.Get(entity);
                if (!removeFreezeTargetEffectRequest.Target.Unpack(_world, out var target))
                    continue;
                _freezeTargetEffectPool.Del(target);
            }
        }
    }
}