namespace UniGame.Ecs.Proto.Ability.SubFeatures.Movement.Systems
{
    using Common.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Proto.Movement.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class UnblockMovementSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CanBlockMovementComponent>()
                .Inc<OwnerComponent>()
                .Inc<CompleteAbilitySelfRequest>()
                .End();
        }
        
        public void Run()
        {
            var ownerPool = _world.GetPool<OwnerComponent>();
            var blockPool = _world.GetPool<ImmobilityComponent>();

            foreach (var entity in _filter)
            {
                ref var owner = ref ownerPool.Get(entity);
                if(!owner.Value.Unpack(_world, out var ownerEntity))
                    continue;
                
                if(!blockPool.Has(ownerEntity))
                    continue;

                ref var block = ref blockPool.Get(ownerEntity);
                var blockCounter = block.BlockSourceCounter;
                blockCounter = Mathf.Clamp(blockCounter - 1, 0, int.MaxValue);
                block.BlockSourceCounter = blockCounter;
            }
        }
    }
}