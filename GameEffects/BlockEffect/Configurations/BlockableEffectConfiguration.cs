namespace UniGame.Ecs.Proto.GameEffects.DamageEffect
{
    using System;
    using Characteristics.Dodge.Components;
    using Effects;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class BlockableEffectConfiguration : EffectConfiguration
    {
        protected override void Compose(ProtoWorld world, ProtoEntity effectEntity)
        {
            var blockableDamageComponent = world.GetOrAddComponent<BlockableDamageComponent>(effectEntity);
        }
    }
}