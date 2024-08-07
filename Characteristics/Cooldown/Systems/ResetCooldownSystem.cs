namespace UniGame.Ecs.Proto.Characteristics.Cooldown.Systems
{
    using System;
    using Aspects;
    using Base.Components.Events;
    using Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// System for resetting cooldowns on entities.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ResetCooldownSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private CooldownAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<BaseCooldownComponent>()
            .Inc<ResetCharacteristicsEvent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var baseCooldown = ref _aspect.BaseCooldown.Get(entity);
                baseCooldown.Modifications.Clear();
                
                if (!_aspect.RecalculateCooldown.Has(entity))
                    _aspect.RecalculateCooldown.Add(entity);
            }
        }
    }
}