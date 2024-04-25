namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySequence.Bahaviours.Aspects
{
    using System;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class AbilitySequenceOnStartAspect : EcsAspect
    {
        public ProtoPool<ActivateSequenceTriggerComponent> ActivateTrigger;
        public ProtoPool<OwnerComponent> Owner;
    }
}