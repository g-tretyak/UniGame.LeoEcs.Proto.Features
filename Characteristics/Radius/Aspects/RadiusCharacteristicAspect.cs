namespace UniGame.Ecs.Proto.Characteristics.Radius
{
    using System;
    using Base.Aspects;
    using Base.Components;
    using Component;
    using Leopotam.EcsProto;

    /// <summary>
    /// Aspect for the Radius characteristic.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class RadiusCharacteristicAspect : GameCharacteristicAspect<RadiusComponent>
    {
        public ProtoPool<RadiusComponent> Radius;
        public ProtoPool<CharacteristicComponent<RadiusComponent>> RadiusCharacteristic;
    }
}