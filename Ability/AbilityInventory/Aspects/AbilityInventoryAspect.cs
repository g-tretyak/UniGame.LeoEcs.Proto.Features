namespace UniGame.Ecs.Proto.AbilityInventory.Aspects
{
    using System;
    using Ability.Common.Components;
    using Ability.Components;
    using Ability.SubFeatures.AbilityAnimation.Components;
    using Components;
    using Equip.Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class AbilityInventoryAspect : EcsAspect
    {
        public ProtoPool<AbilityIdComponent> Id;
        public ProtoPool<AbilityEquipComponent> AbilityEquip;
        public ProtoPool<AbilityBuildingComponent> Building;
        public ProtoPool<AbilityBlockedComponent> Blocked;
        public ProtoPool<AbilityVisualComponent> Visual;
        public ProtoPool<AbilitySlotComponent> Slot;
        public ProtoPool<UserInputAbilityComponent> Input;
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<OwnerLinkComponent> OwnerLink;
        public ProtoPool<AbilityActiveAnimationComponent> Animation;
        public ProtoPool<AbilityMetaLinkComponent> MetaLink;
        public ProtoPool<AbilityConfigurationComponent> Configuration;
        public ProtoPool<AbilityBuildingProcessingComponent> Processing;
        public ProtoPool<AbilityLoadingComponent> Loading;
        public ProtoPool<AbilityInventoryCompleteComponent> Complete;
        public ProtoPool<AbilityValidationFailedComponent> Failed;
        public ProtoPool<AbilityInventoryProfileComponent> ProfileTarget;

        //requests
        public ProtoPool<EquipAbilityIdSelfRequest> EquipById;
        public ProtoPool<EquipAbilityIdToChampionRequest> EquipToChampion;
        public ProtoPool<EquipAbilityNameSelfRequest> EquipByName;
        public ProtoPool<EquipAbilityReferenceSelfRequest> EquipByReference;
        public ProtoPool<EquipAbilitySelfRequest> Equip;
        public ProtoPool<LoadAbilityMetaRequest> LoadMeta;
        
        //event
        public ProtoPool<AbilityEquipChangedEvent> EquipChanged;
    }
}