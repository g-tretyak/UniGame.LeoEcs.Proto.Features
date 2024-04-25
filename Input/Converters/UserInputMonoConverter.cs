using UniCore.Runtime.ProfilerTools;

namespace unigame.ecs.proto.Input.Converters
{
    using System.Threading;
    using Components;
     
    using UniGame.LeoEcs.Converter.Runtime;
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