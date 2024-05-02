namespace UniGame.Ecs.Proto.Core.Death.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UnityEngine.Playables;

    [Serializable]
    public sealed class DeathAnimationConverter : LeoEcsConverter
    {
        [SerializeField]
        public PlayableAsset deadAnimation;

        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            if (deadAnimation == null) return;
            
            var deathAnimationPool = world.GetPool<DeathAnimationComponent>();
            ref var deathAnimation = ref deathAnimationPool.Add(entity);
            deathAnimation.Animation = deadAnimation;
        }
    }
}