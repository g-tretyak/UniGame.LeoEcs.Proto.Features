namespace unigame.ecs.proto.Ability.SubFeatures.Target.Systems
{
    using Common.Components;
    using Components;
    using Core.Components;
    using Ecs.Effects;
    using Ecs.Effects.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    [ECSDI]
    public sealed class InstantlyApplyAbilityEffectsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<ApplyAbilityEffectsSelfRequest> _applyRequestPool;
        private ProtoPool<EffectsComponent> _effectsPool;
        private ProtoPool<OwnerComponent> _ownerPool;
        private ProtoPool<AbilityTargetsComponent> _targetsPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<CanInstantlyApplyEffects>()
                .Inc<ApplyAbilityEffectsSelfRequest>()
                .Inc<EffectsComponent>()
                .Inc<OwnerComponent>()
                .Inc<AbilityTargetsComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var owner = ref _ownerPool.Get(entity);

                ref var effects = ref _effectsPool.Get(entity);
                ref var targets = ref _targetsPool.Get(entity);

                var amount = targets.Count;
                for (var i = 0; i < amount; i++)
                {
                    ref var target = ref targets.Entities[i];
                    effects.Effects.CreateRequests(_world, owner.Value, target);
                }
            }
        }
    }
}