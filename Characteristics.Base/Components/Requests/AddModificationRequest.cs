namespace unigame.ecs.proto.Characteristics.Base.Components.Requests
{
    using System;
    using Leopotam.EcsProto.QoL;
    using Modification;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

    /// <summary>
    /// Add modification of parameter
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct AddModificationRequest
    {
        //modification source
        public ProtoPackedEntity Source;
        //target characteristic
        public ProtoPackedEntity Target;
        //modification value
        public Modification Modification;
    }
}