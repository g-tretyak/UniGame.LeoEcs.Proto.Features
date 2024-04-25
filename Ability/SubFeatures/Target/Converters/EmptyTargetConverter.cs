namespace unigame.ecs.proto.Ability.SubFeatures.Target.Converters
{
    using System;
    using System.Threading;
    using Components;
     
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class EmptyTargetConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            world.AddComponent<EmptyTargetComponent>(entity);
        }
    }
}