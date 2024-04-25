namespace unigame.ecs.proto.Animations.Aspects
{
    using System;
    using Characteristics.Duration.Components;
    using Components;
    using Components.Requests;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class PlayableAnimatorAspect : EcsAspect
    {
        public ProtoPool<PlayableDirectorComponent> Director;
        public ProtoPool<AnimatorPlayingComponent> PlayingTarget;
        public ProtoPool<DurationComponent> Duration;
        
        //optional / statuses
        public ProtoPool<AnimationPlayingComponent> Playing;


        public ProtoPool<PlayOnDirectorSelfRequest> Play;
        public ProtoPool<StopAnimationSelfRequest> StopSelf;
    }
}