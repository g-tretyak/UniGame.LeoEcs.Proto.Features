using Game.Ecs.Audio.AudioCore.Components;
using Game.Ecs.Audio.AudioCore.Components.Requests;
using Game.Ecs.Audio.AudioCore.Converter;
using Leopotam.EcsProto;

namespace Game.Ecs.Audio.AudioCore.Aspects
{
    using System;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

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
    public class AudioCoreAspect : EcsAspect
    {
        public ProtoPool<StopFMODEventRequest> StopFMODEventRequest;
        public ProtoPool<ContinuousAudioComponent> ContinuousAudio;
        
        public ProtoPool<AudioListenerRootComponent> AudioListenerRoot;
        public ProtoPool<AudioListenerTransformComponent> AudioListenerTransform;
    }
}