namespace UniGame.Ecs.Proto.Characteristics.Health.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.Ecs.Proto.Characteristics.Base.Components;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class ProcessHealthChangedSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private EcsFilter _filterDestinations;
        private ProtoWorld _world;
        
        private ProtoPool<CharacteristicComponent<HealthComponent>> _characteristicPool;
        private ProtoPool<HealthComponent> _healthPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CharacteristicChangedComponent<HealthComponent>>()
                .Inc<CharacteristicComponent<HealthComponent>>()
                .Inc<HealthComponent>()
                .End();

            _characteristicPool = _world.GetPool<CharacteristicComponent<HealthComponent>>();
            _healthPool = _world.GetPool<HealthComponent>();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _characteristicPool.Get(entity);
                ref var healthComponent = ref _healthPool.Get(entity);
                healthComponent.Health = characteristicComponent.Value;
                healthComponent.MaxHealth = characteristicComponent.MaxValue;
            }
        }
    }
}