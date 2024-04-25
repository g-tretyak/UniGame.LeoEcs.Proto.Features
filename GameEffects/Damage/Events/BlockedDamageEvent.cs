namespace unigame.ecs.proto.Characteristics.Dodge.Components.Events
{
    using System;
    using Leopotam.EcsProto.QoL;
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// attack miss event
    /// </summary>
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct BlockedDamageEvent
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;
    }
}