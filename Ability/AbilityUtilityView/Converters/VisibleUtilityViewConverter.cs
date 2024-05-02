namespace UniGame.Ecs.Proto.Ability.AbilityUtilityView.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class VisibleUtilityViewConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var visiblePool = world.GetPool<VisibleUtilityViewComponent>();
            visiblePool.Add(entity);
        }
    }
}