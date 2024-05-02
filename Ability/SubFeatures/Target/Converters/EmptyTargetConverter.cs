namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class EmptyTargetConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            world.AddComponent<EmptyTargetComponent>(entity);
        }
    }
}