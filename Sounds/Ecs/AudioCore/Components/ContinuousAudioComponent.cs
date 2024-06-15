using FMOD.Studio;
using FMODUnity;
using RoyTheunissen.FMODSyntax;

namespace Game.Ecs.Audio.AudioCore.Components
{
    using System;

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
    public struct ContinuousAudioComponent
    {
        public string Path;
        public FmodAudioPlayback Playback; 
    }
}