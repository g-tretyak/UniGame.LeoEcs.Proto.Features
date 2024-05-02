namespace UniGame.Ecs.Proto.Characteristics.Base.Components.Requests
{
    using System;
    using Leopotam.EcsProto.QoL;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

    /// <summary>
    /// create characteristic parameter
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct CreateCharacteristicRequest<TCharacteristic>
        where TCharacteristic : struct
    {
        public ProtoPackedEntity Owner;
        public float Value;
        public float MinValue;
        public float MaxValue;
    }
}