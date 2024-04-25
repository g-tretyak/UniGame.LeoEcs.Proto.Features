namespace unigame.ecs.proto.Ability.AbilityUtilityView.Highlights.Systems
{
    using Common.Components;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class ProcessNotInHandAbilityHighlightSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<HighlightStateComponent>()
                .Exc<AbilityInHandComponent>()
                .End();
        }
        
        public void Run()
        {
            var highlightStatePool = _world.GetPool<HighlightStateComponent>();
            var hideHighlightPool = _world.GetPool<HideHighlightRequest>();

            foreach (var entity in _filter)
            {
                ref var highlightedState = ref highlightStatePool.Get(entity);
                foreach (var packedEntity in highlightedState.Highlights)
                {
                    var hideRequestEntity = _world.NewEntity();
                    ref var hideRequest = ref hideHighlightPool.Add(hideRequestEntity);
                    
                    hideRequest.Source = entity.PackEntity(_world);
                    hideRequest.Destination = packedEntity.Key;
                }
            }
        }
    }
}