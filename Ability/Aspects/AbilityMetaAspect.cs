namespace unigame.ecs.proto.AbilityInventory.Aspects
{
    using System;
    using Ability.Common.Components;
    using Ability.Components;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class AbilityMetaAspect : EcsAspect
    {
        public ProtoPool<AbilityConfigurationReferenceComponent> ConfigurationReference;
        public ProtoPool<AbilityConfigurationComponent> Configuration;
        public ProtoPool<AbilityVisualComponent> Visual;
        public ProtoPool<NameComponent> Name;
        public ProtoPool<AbilityMetaComponent> Meta;
        public ProtoPool<AbilitySlotComponent> Slot;
        public ProtoPool<AbilityIdComponent> Id;
        public ProtoPool<AbilityBlockedComponent> Blocked;
        //arena specific
        public ProtoPool<AbilityCategoryComponent> Category;
        public ProtoPool<AbilityLevelComponent> Level;
        public ProtoPool<PassiveAbilityComponent> IsPassive;
    }
}