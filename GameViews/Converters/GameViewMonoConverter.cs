namespace unigame.ecs.proto.Gameplay.LevelProgress.Converters
{
    using System;
    using System.Threading;
    using Components;
     
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
        public override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            ref var viewComponent = ref world.GetOrAddComponent<GameViewComponent>(entity);
        }
    }
}