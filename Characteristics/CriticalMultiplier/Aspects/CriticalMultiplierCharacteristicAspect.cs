namespace UniGame.Ecs.Proto.Characteristics.CriticalMultiplier.Aspects
{
    using System;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Leopotam.EcsProto;

    /// <summary>
    /// Represents a game characteristic aspect for critical multiplier.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class CriticalMultiplierCharacteristicAspect : GameCharacteristicAspect<CriticalMultiplierComponent>
    {
        public ProtoPool<CriticalMultiplierComponent> CriticalMultiplier;
        public ProtoPool<CharacteristicComponent<CriticalMultiplierComponent>> CriticalMultiplierCharacteristic;
    }
}