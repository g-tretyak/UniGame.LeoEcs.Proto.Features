namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilityAnimation.Aspects
{
    using System;
    using Animations.Components;
    using Characteristics.Duration.Components;
    using Components;
    using Core.Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Timer.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class AbilityAnimationAspect : EcsAspect
    {
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<AnimationDataLinkComponent> Data;
        public ProtoPool<AbilityActiveAnimationComponent> ActiveAnimation;
        public ProtoPool<LinkToAnimationComponent> AnimationLink;
        public ProtoPool<DurationComponent> Duration;
        public ProtoPool<CooldownComponent> Cooldown;
        public ProtoPool<PlayableDirectorComponent> Director;
    }
}