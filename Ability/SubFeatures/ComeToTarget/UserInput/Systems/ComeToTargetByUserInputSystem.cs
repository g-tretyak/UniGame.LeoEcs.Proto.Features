namespace UniGame.Ecs.Proto.Ability.SubFeatures.ComeToTarget.UserInput.Systems
{
    using Common.Components;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Target.Components;
    using UniGame.LeoEcs.Shared.Extensions;

    [ECSDI]
    public sealed class ComeToTargetByUserInputSystem : IProtoRunSystem
    {
        private ProtoWorld _world;

        private ProtoIt _filter= It
            .Chain<AbilityTargetsOutsideEvent>()
            .Inc<CanComeToTargetComponent>()
            .Inc<AbilityInHandComponent>()
            .Inc<AbilityTargetsComponent>()
            .End();

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