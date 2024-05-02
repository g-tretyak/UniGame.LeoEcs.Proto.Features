namespace UniGame.Ecs.Proto.Ability.SubFeatures.ComeToTarget.UserInput.Systems
{
    using Common.Components;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Target.Components;
    using UniGame.LeoEcs.Shared.Extensions;

    public sealed class ComeToTargetByUserInputSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<AbilityTargetsOutsideEvent>()
                .Inc<CanComeToTargetComponent>()
                .Inc<UserInputAbilityComponent>()
                .Inc<AbilityInHandComponent>()
                .Inc<AbilityTargetsComponent>()
                .End();
        }
        
        public void Run()
        {
            var updatePool = _world.GetPool<UpdateComePointComponent>();
            var deferredPool = _world.GetPool<DeferredAbilityComponent>();

            foreach (var entity in _filter)
            {
                updatePool.GetOrAddComponent(entity);
                deferredPool.GetOrAddComponent(entity);
            }
        }
    }
}