namespace unigame.ecs.proto.Core.Death.Converters
{
    using System;
    using System.Threading;
    using Components;
     
    using UniGame.LeoEcs.Converter.Runtime;
    using UnityEngine;
    using UnityEngine.Playables;

    [Serializable]
    public sealed class DeathAnimationConverter : LeoEcsConverter
    {
        [SerializeField]
        public PlayableAsset deadAnimation;

        public override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            if (deadAnimation == null) return;
            
            var deathAnimationPool = world.GetPool<DeathAnimationComponent>();
            ref var deathAnimation = ref deathAnimationPool.Add(entity);
            deathAnimation.Animation = deadAnimation;
        }
    }
}