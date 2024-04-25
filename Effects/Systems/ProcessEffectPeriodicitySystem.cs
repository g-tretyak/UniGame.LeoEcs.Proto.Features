namespace unigame.ecs.proto.Effects.Systems
{
    using System;
    using Aspects;
    using Components;
     
    using Time.Service;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
    
    /// <summary>
    /// System for processing periodicity of effects
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ProcessEffectPeriodicitySystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        private EffectAspect _effectAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<EffectComponent>()
                .Inc<EffectPeriodicityComponent>()
                .Exc<DestroyEffectSelfRequest>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var periodicity = ref _effectAspect.Periodicity.Get(entity);
                if (periodicity.Periodicity < 0.0f)
                {
                    if (periodicity.LastApplyingTime < Time.time)
                    {
                        periodicity.LastApplyingTime = float.MaxValue;
                        _effectAspect.Apply.TryAdd(entity);
                    }
                    
                    continue;
                }
                
                var nextApplyingTime = periodicity.LastApplyingTime + periodicity.Periodicity;
                if(GameTime.Time < nextApplyingTime && !Mathf.Approximately(nextApplyingTime, GameTime.Time))
                    continue;

                periodicity.LastApplyingTime = GameTime.Time;
                
                _effectAspect.Apply.TryAdd(entity);
            }
        }
    }
}