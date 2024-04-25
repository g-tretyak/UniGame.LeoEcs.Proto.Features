namespace unigame.ecs.proto.Ability.SubFeatures.Target.Converters
{
    using System;
    using System.Threading;
    using Components;
     
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UnityEngine;

    [Serializable]
    public sealed class LookAtWhenAbilityApplyConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            var canRotatePool = world.GetPool<CanLookAtComponent>();
            canRotatePool.Add(entity);
        }
    }
}