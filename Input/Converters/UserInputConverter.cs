namespace unigame.ecs.proto.Input.Converters
{
    using System;
    using System.Threading;
    using Components;
     
    using UniGame.LeoEcs.Converter.Runtime;
    using UnityEngine;

    [Serializable]
    public sealed class UserInputConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var inputTargetPool = world.GetPool<UserInputTargetComponent>();
            inputTargetPool.Add(entity);
        }
    }
}