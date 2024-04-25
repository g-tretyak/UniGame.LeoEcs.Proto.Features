namespace unigame.ecs.proto.Camera.Converters
{
    using System.Threading;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class CameraFollowTargetMonoConverter : MonoLeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var followTargetPool = world.GetPool<CameraFollowTargetComponent>();
            followTargetPool.Add(entity);
        }
    }
}