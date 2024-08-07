namespace UniGame.Ecs.Proto.Characteristics.AbilityPower.Aspects
{
    using System;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Components.Requests;
    using Leopotam.EcsProto;

    /// <summary>
    /// Aspect for the AbilityPower characteristic in a game.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class AbilityPowerCharacteristicAspect : GameCharacteristicAspect<AbilityPowerComponent>
    {
        // Components
        public ProtoPool<AbilityPowerComponent> AbilityPower;
        public ProtoPool<CharacteristicComponent<AbilityPowerComponent>> AbilityPowerCharacteristic;
        // requests
        public ProtoPool<RecalculateAbilityPowerRequest> RecalculateAbilityPowerRequest;
    }
}