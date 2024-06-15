using System;
using System.Collections.Generic;
using Animancer;
using Game.Code.Services.Animation.Data.AnimnationsData;

namespace Game.Ecs.Animation.AnimationCore.Components
{
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
    public struct AnimationsEventsComponent
    {
        public List<AnimationEntry> AnimationEntries;
        public List<AnimancerEvent.Sequence> Events;
    }
}