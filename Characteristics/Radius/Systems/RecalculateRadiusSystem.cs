namespace unigame.ecs.proto.Characteristics.Radius.Systems
{
    using Base.Components;
    using Component;
     

    public sealed class RecalculateRadiusSystem : IProtoRunSystem,IProtoInitSystem
    {
        
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<CharacteristicComponent<RadiusComponent>> _characteristicPool;
        private ProtoPool<RadiusComponent> _characteristicComponentPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CharacteristicChangedComponent<RadiusComponent>>()
                .Inc<CharacteristicComponent<RadiusComponent>>()
                .Inc<RadiusComponent>()
                .End();

            _characteristicPool = _world.GetPool<CharacteristicComponent<RadiusComponent>>();
            _characteristicComponentPool = _world.GetPool<RadiusComponent>();
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