namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Converters
{
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class LookAtWhenAbilityApplyMonoConverter : MonoLeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var canRotatePool = world.GetPool<CanLookAtComponent>();
            canRotatePool.Add(entity);
        }
    }
}