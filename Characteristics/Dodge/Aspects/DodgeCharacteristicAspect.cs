namespace UniGame.Ecs.Proto.Characteristics.Dodge.Aspects
{
    using System;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Leopotam.EcsProto;

    /// <summary>
    /// Represents a game characteristic aspect for dodge.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class DodgeCharacteristicAspect : GameCharacteristicAspect<DodgeComponent>
    {
        public ProtoPool<DodgeComponent> Dodge;
        public ProtoPool<CharacteristicComponent<DodgeComponent>> DodgeDodgeCharacteristic;
    }
}