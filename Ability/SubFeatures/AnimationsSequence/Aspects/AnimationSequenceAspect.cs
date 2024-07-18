namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Aspects
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class AnimationSequenceAspect : EcsAspect
    {
        public ProtoPool<AbilityAnimationVariantCounterComponent> AnimationVariantCounter;
        public ProtoPool<AbilityAnimationVariantComponent> AnimationVariant;
        public ProtoPool<AbilityAnimationVariantsComponent> AnimationVariants;
        public ProtoPool<LinearAbilityAnimationSelectionComponent> LinearAbilityAnimationSelection;
    }
}