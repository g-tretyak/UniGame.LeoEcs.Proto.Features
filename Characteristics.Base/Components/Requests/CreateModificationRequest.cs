namespace UniGame.Ecs.Proto.Characteristics.Base
{
    using System;
    using Leopotam.EcsProto.QoL;
    
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
    
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct CreateModificationRequest<TCharacteristic>
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Target;
        public float Value;
    }
    
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct CreateModificationRequest
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Target;
        public Modification Modification;
    }
}