namespace UniGame.Ecs.Proto.Gameplay.LevelProgress.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Converter.Runtime.Converters;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class GameViewMonoConverter : MonoLeoEcsConverter<GameViewConverter>
    {
        
    }

    [Serializable]
    public class GameViewConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var viewComponent = ref world.GetOrAddComponent<GameViewComponent>(entity);
        }
    }
}