namespace UniGame.Ecs.Proto.Gameplay.Damage.Components.Events
{
    using System;
    using Leopotam.EcsProto.QoL;
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// notify about block damage
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct BlockedDamageEvent
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;
    }
}