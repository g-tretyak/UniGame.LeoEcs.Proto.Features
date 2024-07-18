namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Aspects
{
    using System;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Movement.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    [Serializable]
    public class AbilityMovementAspect : EcsAspect
    {
        ProtoPool<CanBlockMovementComponent> CanBlockMovement;
    }
}