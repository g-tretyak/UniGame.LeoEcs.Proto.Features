namespace unigame.ecs.proto.Core.Death.Converters
{
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UnityEngine.Playables;

    public sealed class DeathAnimationMonoConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        public PlayableAsset deadAnimation;

        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            if (deadAnimation == null) return;
            
            var deathAnimationPool = world.GetPool<DeathAnimationComponent>();
            ref var deathAnimationComponent = ref deathAnimationPool.Add(entity);
            deathAnimationComponent.Animation = deadAnimation;
        }
    }
}