namespace UniGame.Ecs.Proto.Characteristics.Base.Aspects
{
    using System;
    using Components.Requests.OwnerRequests;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// modification aspect of characteristic value
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class CharacteristicModificationAspect<TCharacteristic> : EcsAspect 
        where TCharacteristic : struct
    {
        
        //requests
        public ProtoPool<AddModificationRequest<TCharacteristic>> AddModification;
        public ProtoPool<RemoveCharacteristicModificationRequest<TCharacteristic>> RemoveModification;
        public ProtoPool<ResetCharacteristicModificationsSelfRequest<TCharacteristic>> RemoveSelfModifications;
        public ProtoPool<CreateModificationRequest<TCharacteristic>> CreateModification;
    }
}