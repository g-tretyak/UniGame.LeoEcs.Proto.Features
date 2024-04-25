namespace unigame.ecs.proto.GameEffects.TeleportEffect
{
    using System;
    using Components;
    using Effects;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    [Serializable]
    public sealed class TeleportEffectConfiguration : EffectConfiguration
    {
        protected override void Compose(ProtoWorld world, int effectEntity)
        {
            var teleportPool = world.GetPool<TeleportEffectComponent>();
            teleportPool.Add(effectEntity);
        }
    }
}