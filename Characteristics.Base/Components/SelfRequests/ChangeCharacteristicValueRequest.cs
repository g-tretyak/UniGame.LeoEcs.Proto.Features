namespace unigame.ecs.proto.Characteristics.Base.Components.Requests.OwnerRequests
{
    using System;
    using Leopotam.EcsProto.QoL;


#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
    
    /// <summary>
    /// Change characteristic T value request
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct ChangeCharacteristicValueRequest<TCharacteristic>
        where TCharacteristic : struct
    {
        public ProtoPackedEntity Target;
        public ProtoPackedEntity Source;
        public float Value;
    }
}