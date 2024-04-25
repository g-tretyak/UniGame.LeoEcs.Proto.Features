namespace unigame.ecs.proto.Ability.SubFeatures.AbilityAnimation.Aspects
{
    using System;
    using Components;
    using Core.Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class AbilityAnimationOptionAspect : EcsAspect
    {
        public ProtoPool<AbilityAnimationOptionComponent> Option;
        public ProtoPool<AnimationDataLinkComponent> Data;
        public ProtoPool<OwnerComponent> Owner;
    }
}