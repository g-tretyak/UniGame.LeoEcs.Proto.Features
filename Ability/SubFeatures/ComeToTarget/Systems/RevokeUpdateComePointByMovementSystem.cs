namespace unigame.ecs.proto.Ability.SubFeatures.ComeToTarget.Systems
{
    using Components;
    using Game.Ecs.Core.Components;
    using Input.Components.Direction;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Movement.Components;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class RevokeUpdateComePointByMovementSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<UpdateComePointComponent>()
                .Inc<OwnerComponent>()
                .End();
        }
        
        public void Run()
        {
            var updatePool = _world.GetPool<UpdateComePointComponent>();
            var ownerPool = _world.GetPool<OwnerComponent>();

            var inputPool = _world.GetPool<DirectionInputEvent>();
            
            var deferredPool = _world.GetPool<DeferredAbilityComponent>();
            var requestPool = _world.GetPool<RevokeComeToEndOfRequest>();

            foreach (var entity in _filter)
            {
                ref var owner = ref ownerPool.Get(entity);
                if(!owner.Value.Unpack(_world, out var ownerEntity))
                    continue;
                
                if(!inputPool.Has(ownerEntity))
                    continue;
                
                deferredPool.Del(entity);
                updatePool.Del(entity);

                if (!requestPool.Has(ownerEntity))
                    requestPool.Add(ownerEntity);
            }
        }
    }
}