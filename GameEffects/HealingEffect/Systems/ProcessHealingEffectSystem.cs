namespace UniGame.Ecs.Proto.GameEffects.HealingEffect.Systems
{
    using Characteristics.Base.Components.Requests.OwnerRequests;
    using Characteristics.Health.Components;
    using Components;
    using Effects.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    [ECSDI]
    public sealed class ProcessHealingEffectSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<EffectComponent> effectPool;
        private ProtoPool<HealingEffectComponent> healingPool;
        private ProtoPool<ChangeCharacteristicBaseRequest<HealthComponent>> changeHealthPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<EffectComponent>()
                .Inc<ApplyEffectSelfRequest>()
                .Inc<HealingEffectComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var effect = ref effectPool.Get(entity);
                ref var healing = ref healingPool.Get(entity);

                var healthRequestEntity = _world.NewEntity();
                ref var healthRequest = ref changeHealthPool.Add(healthRequestEntity);
                healthRequest.Source = effect.Source;
                healthRequest.Target = effect.Destination;
                healthRequest.Value = healing.Value;
            }
        }
    }
}