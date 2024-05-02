namespace UniGame.Ecs.Proto.GameEffects.ImmobilityEffect
{
    using System;
    using Components;
    using Effects;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    [Serializable]
    public sealed class ImmobilityEffectConfiguration : EffectConfiguration
    {
        protected override void Compose(ProtoWorld world, ProtoEntity effectEntity)
        {
            var immobilityPool = world.GetPool<ImmobilityEffectComponent>();
            immobilityPool.Add(effectEntity);
        }
    }
}