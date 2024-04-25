namespace unigame.ecs.proto.Characteristics.Base.Components.Requests.OwnerRequests
{
    using System;
    using Leopotam.EcsProto.QoL;
    using Modification;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
    
    /// <summary>
    /// add modification to characteristic by target and type
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct AddModificationRequest<TCharacteristic>
        where TCharacteristic : struct
    {
        //target modification
        public ProtoPackedEntity Target;
        //modification source
        public ProtoPackedEntity ModificationSource;
        //modification value
        public Modification Modification;
    }
}