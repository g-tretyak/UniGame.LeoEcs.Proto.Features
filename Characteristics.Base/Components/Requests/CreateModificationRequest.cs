namespace unigame.ecs.proto.Characteristics.Base.Components.Requests
{
    using System;
    using Leopotam.EcsProto.QoL;
    using Modification;

    /// <summary>
    /// Add modification of parameter
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct CreateModificationRequest
    {
        //modification source
        public ProtoPackedEntity ModificationSource;
        //target characteristic
        public ProtoPackedEntity Target;
        //modification value
        public Modification Modification;
    }
}