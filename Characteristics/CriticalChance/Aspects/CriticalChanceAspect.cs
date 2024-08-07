namespace UniGame.Ecs.Proto.Characteristics.CriticalChance.Aspects
{
    using System;
    using Attack.Components;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Leopotam.EcsProto;

    /// <summary>
    /// Represents a game characteristic aspect for critical chance.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class CriticalChanceAspect : GameCharacteristicAspect<CriticalChanceComponent>
    {
        public ProtoPool<CriticalChanceComponent> CriticalChance;
        public ProtoPool<CharacteristicComponent<CriticalChanceComponent>> CriticalChanceCharacteristic;
        public ProtoPool<RecalculateCriticalChanceRequest> Recalculate;
    }
}