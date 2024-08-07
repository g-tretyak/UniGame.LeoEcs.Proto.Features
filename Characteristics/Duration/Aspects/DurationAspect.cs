namespace UniGame.Ecs.Proto.Characteristics.Duration.Aspects
{
    using System;
    using Base.Aspects;
    using Components;
    using Components.Requests;
    using Leopotam.EcsProto;

    /// <summary>
    /// Aspect representing the duration characteristic for a feature.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class DurationAspect : GameCharacteristicAspect<DurationComponent>
    {
        public ProtoPool<DurationComponent> Duration;
        public ProtoPool<BaseDurationComponent> BaseDuration;
        public ProtoPool<RecalculateDurationRequest> RecalculateDuration;
    }
}