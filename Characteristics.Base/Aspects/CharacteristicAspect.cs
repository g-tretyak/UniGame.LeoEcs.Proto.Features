namespace UniGame.Ecs.Proto.Characteristics.Base.Aspects
{
    using System;
    using Components.Events;
    using Components.Requests;
    using Components.Requests.OwnerRequests;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// new characteristic aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class CharacteristicAspect<TCharacteristic> : EcsAspect 
        where TCharacteristic : struct
    {
        //requests
        public ProtoPool<CreateCharacteristicRequest<TCharacteristic>> Create;
        public ProtoPool<ResetCharacteristicMaxLimitSelfRequest<TCharacteristic>> Reset;
        public ProtoPool<ChangeMinLimitSelfRequest<TCharacteristic>> ChangeMinLimit;
        public ProtoPool<ChangeCharacteristicValueRequest<TCharacteristic>> ChangeValue;
        public ProtoPool<ChangeMaxLimitSelfRequest<TCharacteristic>> ChangeMaxLimit;
        public ProtoPool<ChangeCharacteristicBaseRequest<TCharacteristic>> ChangeBaseValue;
        public ProtoPool<ResetCharacteristicSelfRequest<TCharacteristic>> ResetValue;
        public ProtoPool<ResetCharacteristicModificationsSelfRequest<TCharacteristic>> ResetModifications;
        public ProtoPool<RecalculateCharacteristicSelfRequest<TCharacteristic>> Recalculate;
        
        //events
        public ProtoPool<CharacteristicValueChangedEvent<TCharacteristic>> OnValueChanged;
        public ProtoPool<ResetCharacteristicsEvent> OnCharacteristicsReset;
    }
}