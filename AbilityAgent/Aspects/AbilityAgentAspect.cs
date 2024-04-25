namespace unigame.ecs.proto.AbilityAgent.Aspects
{
    using System;
    using Ability.Common.Components;
    using Ability.Components;
    using AbilityInventory.Components;
    using Components;
    using Core.Components;
    using Effects.Components;
    using Gameplay.LevelProgress.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Components;

    /// <summary>
    /// Ability agent aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class AbilityAgentAspect : EcsAspect
    {
        public ProtoPool<AbilityMapComponent> AbilityMapComponent;
        public ProtoPool<AbilityAgentComponent> AbilityAgentComponent;
        public ProtoPool<DefaultAbilityTargetSlotComponent> DefaultSlotComponent;
        public ProtoPool<AbilityAgentReadyComponent> AbilityAgentReadyComponent;
        public ProtoPool<AbilityInHandLinkComponent> AbilityInHandLinkComponent;
        public ProtoPool<EntityAvatarComponent> EntityAvatarComponent;
        public ProtoPool<EffectRootComponent> EffectRootComponent;
        public ProtoPool<OwnerComponent> OwnerComponent;
        public ProtoPool<AbilityAgentConfigurationComponent> AbilityAgentConfigurationComponent;
        public ProtoPool<AbilityAgentUnitOwnerComponent> AbilityAgentUnitOwnerComponent;

        public ProtoPool<EquipAbilityIdSelfRequest> EquipAbilityIdSelfRequest;
        public ProtoPool<CreateAbilityAgentSelfRequest> CreateAbilityAgentSelfRequest;
    }
}