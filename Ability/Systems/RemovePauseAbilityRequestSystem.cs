namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Remove the ability pause component
    /// </summary>

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public class RemovePauseAbilityRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private ProtoPool<RemovePauseAbilityRequest> _removePauseAbilityRequestPool;
        private ProtoPool<AbilityPauseComponent> _pauseAbilityPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<RemovePauseAbilityRequest>()
                .End();
            _removePauseAbilityRequestPool = _world.GetPool<RemovePauseAbilityRequest>();
            _pauseAbilityPool = _world.GetPool<AbilityPauseComponent>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var pauseAbilityRequest = ref _removePauseAbilityRequestPool.Get(entity);
                if (!pauseAbilityRequest.AbilityEntity.Unpack(_world, out var abilityEntity))
                    continue;
                _pauseAbilityPool.TryRemove(abilityEntity);
            }
        }
    }
}