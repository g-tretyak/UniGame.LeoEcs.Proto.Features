namespace UniGame.Ecs.Proto.Characteristics.Health.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.Ecs.Proto.Characteristics.Base.Components;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
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