namespace unigame.ecs.proto.Characteristics.Duration.Systems
{
    using Base.Components.Events;
    using Components;
     

    public sealed class ResetDurationSystem : IProtoRunSystem,IProtoInitSystem
    {
        
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<BaseDurationComponent>()
                .Inc<ResetCharacteristicsEvent>()
                .End();
        }
        
        public void Run()
        {
            var baseDurationPool = _world.GetPool<BaseDurationComponent>();
            var requestPool = _world.GetPool<RecalculateDurationRequest>();

            foreach (var entity in _filter)
            {
                ref var baseDuration = ref baseDurationPool.Get(entity);
                baseDuration.Modifications.Clear();
                
                if (!requestPool.Has(entity))
                    requestPool.Add(entity);
            }
        }
    }
}