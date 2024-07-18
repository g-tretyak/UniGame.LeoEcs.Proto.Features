namespace UniGame.Ecs.Proto.Ability.Aspects
{
    using System;
    using AbilityInventory.Components;
    using Characteristics.Cooldown.Components;
    using Characteristics.Duration.Components;
    using Characteristics.Radius.Component;
    using Common.Components;
    using Components;
    using Components.Requests;
    using Core.Components;
    using Game.Ecs.Core.Components;
    using Game.Ecs.Input.Components.Evetns;
    using GameLayers.Category.Components;
    using GameLayers.Relationship.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Timer.Components;

    [Serializable]
    public class AbilityAspect : EcsAspect
    {
        public ProtoPool<AbilityUnlockComponent> Unlock;
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<ActiveAbilityComponent> Active;
        public ProtoPool<DefaultAbilityComponent> Default;
        public ProtoPool<UserInputAbilityComponent> Input;
        public ProtoPool<AbilitySlotComponent> Slot;
        public ProtoPool<AbilityIdComponent> AbilityId;
        public ProtoPool<NameComponent> Name;
        public ProtoPool<IconComponent> Icon;
        public ProtoPool<CategoryIdComponent> Category;
        public ProtoPool<OwnerLinkComponent> OwnerLink;
        public ProtoPool<DurationComponent> Duration;
        public ProtoPool<AnimationDataLinkComponent> AnimationLink;
        public ProtoPool<RelationshipIdComponent> Relationship;
        public ProtoPool<BaseCooldownComponent> BaseCooldown;
        public ProtoPool<CooldownComponent> Cooldown;
        public ProtoPool<CooldownStateComponent> CooldownState;
        public ProtoPool<RadiusComponent> Radius;
        public ProtoPool<DescriptionComponent> Description;
        public ProtoPool<AbilityConfigurationComponent> Configuration;
        public ProtoPool<AbilityEffectMilestonesComponent> EffectMilestones;
        public ProtoPool<AbilityInHandComponent> InHand;
        public ProtoPool<AbilityPauseComponent> Pause;
        public ProtoPool<EntityAvatarComponent> Avatar;
        public ProtoPool<AbilityMapComponent> AbilityMap;
        public ProtoPool<AbilityEquippedComponent> AbilityEquipped;
        
        public ProtoPool<AbilityEvaluationComponent> Evaluate;
        
        //is ability in use
        public ProtoPool<AbilityUsingComponent> AbilityUsing;
        
        //requests
        
        public ProtoPool<ApplyAbilityEffectsSelfRequest> ApplyAbilityEffects;
        public ProtoPool<ActivateAbilityRequest> ActivateAbilityOnTarget;
        public ProtoPool<SetInHandAbilityBySlotSelfRequest> SetInHandAbilityBySlot;
        public ProtoPool<ActivateAbilityByIdRequest> ActivateAbilityById;
        //complete ability
        public ProtoPool<CompleteAbilitySelfRequest> CompleteAbility;
        
        public ProtoPool<AbilityValidationSelfRequest> Validate;
        public ProtoPool<SetAbilityBaseCooldownSelfRequest> SetBaseCooldown;
        public ProtoPool<RecalculateCooldownSelfRequest> RecalculateCooldown;
        
        //activate ability
        public ProtoPool<ActivateAbilitySelfRequest> ActivateAbility;
        public ProtoPool<ApplyAbilityBySlotSelfRequest> ActivateAbilityBySlot;
        
        //requests
        public ProtoPool<EquipAbilityIdSelfRequest> EquipAbilityIdRequest;
        public ProtoPool<PauseAbilityRequest> PauseAbility;
        public ProtoPool<RemovePauseAbilityRequest> RemovePauseAbility;
        
        //events
        public ProtoPool<AbilityStartUsingSelfEvent> UsingEvent;
        public ProtoPool<AbilityCompleteSelfEvent> CompleteEvent;
        public ProtoPool<AbilityVelocityEvent> AbilityVelocityEvent;
        public ProtoPool<AbilityCellVelocityEvent> AbilityCellVelocityEvent;
        public ProtoPool<AbilityUnlockEvent> AbilityUnlockEvent;
        
        
    }
}