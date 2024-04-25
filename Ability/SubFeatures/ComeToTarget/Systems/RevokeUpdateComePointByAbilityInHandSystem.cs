namespace unigame.ecs.proto.Ability.SubFeatures.ComeToTarget.Systems
{
    using Common.Components;
    using Components;
    using Core.Components;
    using Ecs.Movement.Components;
     

    public sealed class RevokeUpdateComePointByAbilityInHandSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<UpdateComePointComponent>()
                .Inc<OwnerComponent>()
                .Exc<AbilityInHandComponent>()
                .End();
        }

        public void Run()
        {
            var updatePool = _world.GetPool<UpdateComePointComponent>();
            var ownerPool = _world.GetPool<OwnerComponent>();

            var deferredPool = _world.GetPool<DeferredAbilityComponent>();
            var requestPool = _world.GetPool<RevokeComeToEndOfRequest>();

            foreach (var entity in _filter)
            {
                ref var owner = ref ownerPool.Get(entity);
                if (!owner.Value.Unpack(_world, out var ownerEntity))
                    continue;

                deferredPool.Del(entity);
                updatePool.Del(entity);

                if (!requestPool.Has(ownerEntity))
                    requestPool.Add(ownerEntity);
            }
        }
    }
}