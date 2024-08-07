namespace UniGame.Ecs.Proto.Characteristics.Duration.Systems
{
    using System;
    using Aspects;
    using Characteristics;
    using Components;
    using Components.Requests;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// System for recalculating the duration of entities.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class RecalculateDurationSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private DurationAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<RecalculateDurationRequest>()
            .Inc<BaseDurationComponent>()
            .Inc<DurationComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var baseDuration = ref _aspect.BaseDuration.Get(entity);
                ref var duration = ref _aspect.Duration.Get(entity);

                duration.Value = baseDuration.Modifications.Apply(baseDuration.Value);
            }
        }
    }
}