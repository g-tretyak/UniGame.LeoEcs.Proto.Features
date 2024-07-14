namespace UniGame.Ecs.Proto.Ability.Common.Components
{
    using System;
    using Game.Code.Configuration.Runtime.Ability;
    using Leopotam.EcsProto.QoL;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

    /// <summary>
    /// create new ability for target
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct CreateAbilityRequest
    {
        public ProtoPackedEntity Target;
        public int AbilityId;
        public bool IsDefault;
        public int SlotId;
        public bool IsInput;
    }
    
    /// <summary>
    /// create new ability for target
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct CreateGameAbilityRequest
    {
        public ProtoPackedEntity Target;
        public AbilityConfiguration Configuration;
        public int AbilityId;
        public bool IsDefault;
        public int SlotId;
        public bool IsInput;
    }
}