namespace UniGame.Ecs.Proto.Input.Aspects
{
    using System;
    using Components.Ability;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// ability input
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class AbilityInputAspect : EcsAspect
    {
        //components
        public ProtoPool<AbilityInputState> AbilityInputState;
        
        //requests
        public ProtoPool<AbilityUpInputRequest> AbilityUp;
        
        //events
        public ProtoPool<AbilityVelocityRawEvent> AbilityVelocityRawEvent;
        public ProtoPool<AbilityCellVelocityEvent> AbilityVelocityEvent;
    }
}