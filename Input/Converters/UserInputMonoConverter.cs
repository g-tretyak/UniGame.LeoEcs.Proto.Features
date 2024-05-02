using UniCore.Runtime.ProfilerTools;

namespace UniGame.Ecs.Proto.Input.Converters
{
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class UserInputMonoConverter : MonoLeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var inputTargetPool = world.GetPool<UserInputTargetComponent>();
            inputTargetPool.Add(entity);
            
            GameLog.Log($"PLAYER ID {entity}",Color.green);
        }
    }
}