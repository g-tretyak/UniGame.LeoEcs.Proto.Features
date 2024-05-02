namespace UniGame.Ecs.Proto.Effects.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
    

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ProcessEffectDurationSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        private EffectAspect _effectAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter= _world
                .Filter<EffectComponent>()
                .Inc<EffectDurationComponent>()
                .Exc<DestroyEffectSelfRequest>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var duration = ref _effectAspect.Duration.Get(entity);
                if(duration.Duration < 0.0f)
                    continue;
                
                var deadTime = duration.CreatingTime + duration.Duration;
                if(Time.time < deadTime && !Mathf.Approximately(deadTime, Time.time))
                    continue;

                _effectAspect.DestroyEffect.TryAdd(entity);
            }
        }
    }
}