namespace UniGame.Ecs.Proto.Characteristics.CriticalChance.Aspects
{
    using System;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Leopotam.EcsProto;

    /// <summary>
    /// Aspect for Attack Range characteristic.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class AttackRangeAspect : GameCharacteristicAspect<AttackRangeComponent>
    {
        public ProtoPool<AttackRangeComponent> AttackRange;
        public ProtoPool<CharacteristicComponent<AttackRangeComponent>> AttackRangeCharacteristic;
    }
}