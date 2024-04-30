namespace unigame.ecs.proto.Movement.Systems.Rigidbody
{
    using Characteristics.Speed.Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// Система отвечающая за пермещени через физическую систему Unity.
    /// </summary>
    public sealed class RigidbodyMovementSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<VelocityComponent>().Inc<RigidbodyComponent>().Inc<SpeedComponent>().End();
        }
        
        public void Run()
        {
            var velocityPool = _world.GetPool<VelocityComponent>();
            var rigidbodyPool = _world.GetPool<RigidbodyComponent>();
            var speedPool = _world.GetPool<SpeedComponent>();

            foreach (var entity in _filter)
            {
                ref var velocityComponent = ref velocityPool.Get(entity);
                ref var rigidbodyComponent = ref rigidbodyPool.Get(entity);
                ref var speedComponent = ref speedPool.Get(entity);

                var rigidbody = rigidbodyComponent.Value;

                var currentPosition = rigidbody.position;
                var nextPosition = currentPosition + velocityComponent.Value * speedComponent.Value * Time.deltaTime;
                rigidbody.MovePosition(nextPosition);
            }
        }
    }
}