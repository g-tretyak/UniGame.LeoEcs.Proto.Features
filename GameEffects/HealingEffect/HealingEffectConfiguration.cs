namespace UniGame.Ecs.Proto.GameEffects.HealingEffect
{
    using System;
    using Components;
    using Effects;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class HealingEffectConfiguration : EffectConfiguration
    {
        [SerializeField]
        [Min(0.0f)]
        public float healingValue;
        
        protected override void Compose(ProtoWorld world, ProtoEntity effectEntity)
        {
            var healingPool = world.GetPool<HealingEffectComponent>();
            ref var healing = ref healingPool.Add(effectEntity);
            healing.Value = healingValue;
        }
    }
}