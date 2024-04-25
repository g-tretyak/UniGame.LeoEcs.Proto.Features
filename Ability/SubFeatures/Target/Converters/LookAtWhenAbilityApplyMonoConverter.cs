namespace unigame.ecs.proto.Ability.SubFeatures.Target.Converters
{
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class LookAtWhenAbilityApplyMonoConverter : MonoLeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            var canRotatePool = world.GetPool<CanLookAtComponent>();
            canRotatePool.Add(entity);
        }
    }
}