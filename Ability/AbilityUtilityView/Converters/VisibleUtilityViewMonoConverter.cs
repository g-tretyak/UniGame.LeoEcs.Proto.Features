namespace UniGame.Ecs.Proto.Ability.AbilityUtilityView.Converters
{
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class VisibleUtilityViewMonoConverter : MonoLeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var visiblePool = world.GetPool<VisibleUtilityViewComponent>();
            visiblePool.Add(entity);
        }
    }
}