namespace UniGame.Ecs.Proto.GameEffects.DamageEffect.Systems
{
    using Characteristics.Attack.Components;
    using Characteristics.AttackDamage;
    using Components;
    using Effects.Components;
    using Gameplay.CriticalAttackChance.Components;
    using Gameplay.Damage.Components.Request;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    [ECSDI]
    public sealed class ProcessAttackDamageEffectSystem : IProtoRunSystem, IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<EffectComponent> _effectPool;
        private ProtoPool<AttackDamageComponent> _attackDamagePool;
        private ProtoPool<CriticalAttackMarkerComponent> _criticalChancePool;
        private ProtoPool<ApplyDamageRequest> _requestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<EffectComponent>()
                .Inc<ApplyEffectSelfRequest>()
                .Inc<AttackDamageEffectComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var effect = ref _effectPool.Get(entity);

                if (!effect.Source.Unpack(_world, out var sourceEntity) || !_attackDamagePool.Has(sourceEntity))
                    continue;

                ref var attackDamage = ref _attackDamagePool.Get(sourceEntity);

                var damage = attackDamage.Value;

                var requestEntity = _world.NewEntity();
                ref var request = ref _requestPool.Add(requestEntity);
                
                request.Source = effect.Source;
                request.Effector = _world.PackEntity(entity);
                request.Destination = effect.Destination;
                request.Value = damage;
                request.IsCritical = _criticalChancePool.Has(sourceEntity);
            }
        }
    }
}