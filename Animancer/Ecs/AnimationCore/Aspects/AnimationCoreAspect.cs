using Game.Ecs.Animation.AnimationCore.Components;
using Game.Ecs.Animation.AnimationCore.Components.Requests;
using Leopotam.EcsProto;

namespace Game.Ecs.Animation.AnimationCore.Aspects
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
    public class AnimationCoreAspect : EcsAspect
    {
        public ProtoPool<AnimancerAnimatorComponent> AnimancerAnimator;
        public ProtoPool<PlayAnimationWithActorRequest> PlayAnimationWithActorRequest;
        public ProtoPool<AnimationsEventsComponent> AnimationsEvents;
    }
}