namespace UniGame.Ecs.Proto.Camera.Converters
{
    using System;
    using System.Threading;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class CameraFollowTargetConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var followTargetPool = world.GetPool<CameraFollowTargetComponent>();
            followTargetPool.Add(entity);
        }
    }
}