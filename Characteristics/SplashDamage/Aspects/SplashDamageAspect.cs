namespace UniGame.Ecs.Proto.Characteristics.SplashDamage.Aspects
{
    using System;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Components.Requests;
    using Leopotam.EcsProto;

    /// <summary>
    /// Represents a game characteristic aspect for splash damage.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class SplashDamageAspect : GameCharacteristicAspect<SplashDamageComponent>
    {
        // Components
        public ProtoPool<SplashDamageComponent> SplashDamage;
        public ProtoPool<CharacteristicComponent<SplashDamageComponent>> SplashDamageCharacteristic;
        // Requests
        public ProtoPool<RecalculateSplashDamageRequest> Recalculate;
    }
}