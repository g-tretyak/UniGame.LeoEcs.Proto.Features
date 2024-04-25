namespace unigame.ecs.proto.Characteristics.Speed.Systems
{
    using Base.Components;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class RecalculateSpeedSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<CharacteristicComponent<SpeedComponent>> _characteristicPool;
        private ProtoPool<SpeedComponent> _characteristicComponentPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CharacteristicChangedComponent<SpeedComponent>>()
                .Inc<CharacteristicComponent<SpeedComponent>>()
                .Inc<SpeedComponent>()
                .End();

            _characteristicPool = _world.GetPool<CharacteristicComponent<SpeedComponent>>();
            _characteristicComponentPool = _world.GetPool<SpeedComponent>();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _characteristicPool.Get(entity);
                ref var characteristicValueComponent = ref _characteristicComponentPool.Get(entity);
                characteristicValueComponent.Value = characteristicComponent.Value;
            }
        }
    }
}