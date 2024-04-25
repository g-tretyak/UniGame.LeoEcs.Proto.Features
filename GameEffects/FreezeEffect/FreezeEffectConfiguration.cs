namespace unigame.ecs.proto.GameEffects.FreezeEffect
{
    using System;
    using Components;
    using Effects;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    [Serializable]
    public sealed class FreezeEffectConfiguration : EffectConfiguration
    {
        protected override void Compose(ProtoWorld world, ProtoEntity effectEntity)
        {
            var freezeEffectPool = world.GetPool<FreezeEffectComponent>();
            freezeEffectPool.Add(effectEntity);
        }
    }
}