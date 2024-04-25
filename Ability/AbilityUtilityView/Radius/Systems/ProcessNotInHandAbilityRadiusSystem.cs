namespace unigame.ecs.proto.Ability.AbilityUtilityView.Radius.Systems
{
    using Common.Components;
    using Component;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class ProcessNotInHandAbilityRadiusSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<RadiusViewStateComponent>()
                .Inc<AbilityIdComponent>()
                .Exc<AbilityInHandComponent>()
                .End();
        }
        
        public void Run()
        {
            var radiusStatePool = _world.GetPool<RadiusViewStateComponent>();
            var hideRadiusPool = _world.GetPool<HideRadiusRequest>();

            foreach (var entity in _filter)
            {
                ref var radiusState = ref radiusStatePool.Get(entity);
                foreach (var packedEntity in radiusState.RadiusViews)
                {
                    var hideRequestEntity = _world.NewEntity();
                    ref var hideRequest = ref hideRadiusPool.Add(hideRequestEntity);
                
                    hideRequest.Source = _world.PackEntity(entity);
                    hideRequest.Destination = packedEntity.Key;
                }
            }
        }
    }
}