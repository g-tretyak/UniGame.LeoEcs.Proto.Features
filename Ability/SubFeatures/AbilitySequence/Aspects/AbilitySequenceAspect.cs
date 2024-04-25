namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySequence.Aspects
{
    using System;
    using Components;
    using AbilitySequence;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class AbilitySequenceAspect : EcsAspect
    {
        public ProtoWorld World;
        //sequence processing data and related ability entities
        public ProtoPool<AbilitySequenceComponent> Sequence;
        //mark sequence as complete
        public ProtoPool<AbilitySequenceFinishedComponent> Finished;
        public ProtoPool<AbilitySequenceAwaitComponent> Await;
        public ProtoPool<AbilitySequenceReadyComponent> Ready;
        //mark sequence as active
        public ProtoPool<AbilitySequenceActiveComponent> Active;
        public ProtoPool<AbilitySequenceLastComponent> Last;
        //mark ability as part of sequence
        public ProtoPool<AbilitySequenceNodeComponent> Node;
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<NameComponent> Name;
        
        //requests
        //create ability sequence by ability ids
        public ProtoPool<CreateAbilitySequenceByIdSelfRequest> CreateById;
        public ProtoPool<CreateAbilitySequenceReferenceSelfRequest> CreateByReference;
        //create ability sequence by exists abilities entity
        public ProtoPool<CreateAbilitySequenceSelfRequest> Create;
        //activate ability sequence by name and owner
        public ProtoPool<ActivateAbilitySequenceByNameRequest> ActivateByName;
        //activate next ability in sequence
        public ProtoPool<ActivateNextAbilityInSequenceSelfRequest> ActivateNextInSequence;
        //activate ability sequence
        public ProtoPool<ActivateAbilitySequenceSelfRequest> Activate;
        public ProtoPool<CompleteAbilitySequenceSelfRequest> Complete;
    }
}