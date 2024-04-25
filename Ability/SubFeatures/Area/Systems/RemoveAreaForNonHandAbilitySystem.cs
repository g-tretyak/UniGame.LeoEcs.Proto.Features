namespace unigame.ecs.proto.Ability.SubFeatures.Area.Systems
{
    using Aspects;
    using Common.Components;
    using Components;
     

    public sealed class RemoveAreaForNonHandAbilitySystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private AreaAspect _areaAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<AreableAbilityComponent>()
                .Inc<AreaLocalPositionComponent>()
                .Exc<AbilityInHandComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                _areaAspect.AreaPosition.Del(entity);
            }
        }
    }
}