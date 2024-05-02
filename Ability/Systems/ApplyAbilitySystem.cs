namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    using System;
    using Aspects;
    using Components;
    using Game.Ecs.Time.Service;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Timer.Components;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ApplyAbilitySystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private AbilityAspect _abilityAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<AbilityValidationSelfRequest>()
                .Inc<CooldownStateComponent>()
                .Inc<ActiveAbilityComponent>()
                .Exc<AbilityUsingComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var abilityCooldownComponent = ref _abilityAspect.CooldownState.Get(entity);
                abilityCooldownComponent.LastTime = GameTime.Time;
                
                _abilityAspect.AbilityUsing.Add(entity);
                _abilityAspect.UsingEvent.Add(entity);
            }
        }
    }
}