namespace UniGame.Ecs.Proto.Characteristics.Duration.Systems
{
    using System;
    using Aspects;
    using Base.Components.Events;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// System for resetting the duration of entities.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ResetDurationSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private DurationAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<BaseDurationComponent>()
            .Inc<ResetCharacteristicsEvent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var baseDuration = ref _aspect.BaseDuration.Get(entity);
                baseDuration.Modifications.Clear();
                
                if (!_aspect.RecalculateDuration.Has(entity))
                    _aspect.RecalculateDuration.Add(entity);
            }
        }
    }
}