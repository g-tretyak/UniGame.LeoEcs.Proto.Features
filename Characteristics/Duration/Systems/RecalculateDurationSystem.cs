namespace unigame.ecs.proto.Characteristics.Duration.Systems
{
    using Base.Modification;
    using Components;
     

    public sealed class RecalculateDurationSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<RecalculateDurationRequest>()
                .Inc<BaseDurationComponent>()
                .Inc<DurationComponent>()
                .End();
        }

        public void Run()
        {
            var baseDurationPool = _world.GetPool<BaseDurationComponent>();
            var durationPool = _world.GetPool<DurationComponent>();

            foreach (var entity in _filter)
            {
                ref var baseDuration = ref baseDurationPool.Get(entity);
                ref var duration = ref durationPool.Get(entity);

                duration.Value = baseDuration.Modifications.Apply(baseDuration.Value);
            }
        }
    }
}