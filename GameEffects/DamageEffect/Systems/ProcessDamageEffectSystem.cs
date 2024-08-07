namespace UniGame.Ecs.Proto.GameEffects.DamageEffect.Systems
{
    using Characteristics.AbilityPower.Components;
    using Components;
    using Effects.Components;
    using Gameplay.Damage.Components.Request;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;

    public sealed class ProcessDamageEffectSystem : IProtoRunSystem, IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        
        private ProtoPool<DamageEffectRequestCompleteComponent> _damageEffectRequestCompletePool;
        private ProtoPool<EffectComponent> _effectPool;
        private ProtoPool<DamageEffectComponent> _damagePool;
        private ProtoPool<AbilityPowerComponent> _abilityPowerPool;
        private ProtoPool<ApplyDamageRequest> _requestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<EffectComponent>()
                .Inc<ApplyEffectSelfRequest>()
                .Inc<DamageEffectComponent>()
                .Exc<DamageEffectRequestCompleteComponent>()
                .End();

            _damageEffectRequestCompletePool = _world.GetPool<DamageEffectRequestCompleteComponent>();
            _effectPool = _world.GetPool<EffectComponent>();
            _damagePool = _world.GetPool<DamageEffectComponent>();
            _abilityPowerPool = _world.GetPool<AbilityPowerComponent>();
            _requestPool = _world.GetPool<ApplyDamageRequest>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var effect = ref _effectPool.Get(entity);
                if (!effect.Destination.Unpack(_world, out var destinationEntity))
                    continue;

                var abilityPower = 1f;
                if (_abilityPowerPool.Has(entity))
                {
                    ref var abilityDamage = ref _abilityPowerPool.Get(entity);
                    abilityPower = abilityDamage.Value;
                }
                
                ref var damage = ref _damagePool.Get(entity);
                var requestEntity = _world.NewEntity();
                ref var request = ref _requestPool.Add(requestEntity);
                request.Source = effect.Source;
                request.Destination = effect.Destination;
                request.Value = damage.Value * abilityPower;
                _damageEffectRequestCompletePool.Add(entity);
            }
        }
    }
}