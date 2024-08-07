namespace UniGame.Ecs.Proto.Characteristics.Shield.Aspects
{
    using System;
    using Base.Aspects;
    using Components;
    using Components.Requests;
    using Leopotam.EcsProto;

    /// <summary>
    /// The ShieldCharacteristicAspect class represents an aspect of a shield characteristic in a game. It is a subclass of the GameCharacteristicAspect class.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class ShieldCharacteristicAspect : GameCharacteristicAspect<ShieldComponent>
    {
        // Components
        public ProtoPool<ShieldComponent> Shield;
        
        // Requests
        public ProtoPool<ChangeShieldRequest> ChangeShield;
    }
}