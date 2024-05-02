namespace UniGame.Ecs.Proto.Characteristics.Shield.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class ProcessShieldSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<ChangeShieldRequest>()
                .End();
        }
        
        public void Run()
        {
            var requestPool = _world.GetPool<ChangeShieldRequest>();
            var shieldPool = _world.GetPool<ShieldComponent>();

            foreach (var entity in _filter)
            {
                ref var request = ref requestPool.Get(entity);
                if(!request.Destination.Unpack(_world, out var destinationEntity) || !shieldPool.Has(destinationEntity))
                    continue;
                
                ref var shield = ref shieldPool.Get(destinationEntity);
                shield.Value += request.Value;
                
                if (shield.Value <= 0.0f || Mathf.Approximately(shield.Value, 0.0f))
                    shieldPool.Del(destinationEntity);
            }
        }
    }
}