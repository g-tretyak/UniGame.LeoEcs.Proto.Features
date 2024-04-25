namespace unigame.ecs.proto.GameEffects.ShieldEffect
{
    using System;
    using Components;
    using Effects;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class ShieldEffectConfiguration : EffectConfiguration
    {
        [SerializeField]
        private float _shieldValue;
        
        protected override void Compose(ProtoWorld world, int effectEntity)
        {
            var shieldPool = world.GetPool<ShieldEffectComponent>();
            ref var shield = ref shieldPool.Add(effectEntity);
            shield.MaxValue = _shieldValue;
        }
    }
}