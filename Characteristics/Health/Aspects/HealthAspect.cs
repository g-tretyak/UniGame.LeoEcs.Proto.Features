namespace UniGame.Ecs.Proto.Characteristics.Health.Aspects
{
    using System;
    using Base;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Leopotam.EcsProto;

    /// <summary>
    /// characteristic Health aspect data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class HealthAspect : GameCharacteristicAspect<HealthComponent>
    {
        // Components
        public ProtoPool<HealthComponent> Health;
        public ProtoPool<CharacteristicComponent<HealthComponent>> HealthCharacteristic;
        
        // Requests
        public ProtoPool<ChangeCharacteristicBaseRequest<HealthComponent>> ChangeBase;
    }
}