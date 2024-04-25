namespace unigame.ecs.proto.GameEffects.DamageEffect
{
    using System;
    using Components;
    using Effects;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class SplashAttackDamageEffectConfiguration : EffectConfiguration
    {
        protected override void Compose(ProtoWorld world, ProtoEntity effectEntity)
        {
            var damagePool = world.GetPool<SplashAttackDamageEffectComponent>();
            damagePool.Add(effectEntity);
        }
    }
}