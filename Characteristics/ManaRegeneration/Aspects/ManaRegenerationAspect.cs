namespace UniGame.Ecs.Proto.Characteristics.ManaRegeneration.Aspects
{
    using System;
    using Base.Aspects;
    using Components;
    using Leopotam.EcsProto;

    /// <summary>
    /// characteristic ManaRegeneration aspect data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ManaRegenerationAspect : GameCharacteristicAspect<ManaRegenerationComponent>
    {
        public ProtoPool<ManaRegenerationComponent> ManaRegeneration;
        public ProtoPool<ManaRegenerationTimerComponent> RegenerationTimer;
    }
}