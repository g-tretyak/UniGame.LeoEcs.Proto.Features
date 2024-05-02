namespace UniGame.Ecs.Proto.Input.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
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