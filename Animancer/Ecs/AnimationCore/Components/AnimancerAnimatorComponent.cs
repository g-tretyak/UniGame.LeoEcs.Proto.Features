using Animancer;
using Game.Code.Services.Animation.Data.AnimacerActorList;

namespace Game.Ecs.Animation.AnimationCore.Components
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
    public struct AnimancerAnimatorComponent
    {
        public AnimancerActorTypeId ActorType;
        public AnimancerComponent AnimancerComponent;
    }
}