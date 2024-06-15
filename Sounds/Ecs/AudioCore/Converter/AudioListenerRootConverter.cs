using Game.Ecs.Audio.AudioCore.Components;
using Leopotam.EcsProto;
using UniGame.LeoEcs.Converter.Runtime;

namespace Game.Ecs.Audio.AudioCore.Converter
{
    using System;
    using UnityEngine;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// 
    /// </summary>

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif

    [Serializable]
    public class AudioListenerRootConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var component = ref world.GetOrAddComponent<AudioListenerRootComponent>(entity);
            component.Root = target.transform;
        }
    }
}