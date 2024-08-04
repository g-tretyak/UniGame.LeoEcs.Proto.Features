﻿namespace UniGame.Ecs.Proto.Ability.Systems
{
    using System;
    using Aspects;
    using Common.Components;
    using Components.Requests;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Tools;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// set new value of cooldown of ability
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class UpdateAbilityCooldownBaseValue : IProtoRunSystem
    {
        private AbilityAspect _abilityTools;
        private ProtoWorld _world;
        private AbilityAspect _abilityAspect;

        private ProtoIt _filter = It
            .Chain<SetAbilityBaseCooldownSelfRequest>()
            .Inc<AbilityMapComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var requestComponent = ref _abilityAspect.SetBaseCooldown.Get(entity);
                var slot = requestComponent.AbilitySlot;
                var cooldown = requestComponent.Cooldown;
                
                var abilityEntity = _abilityTools.TryGetAbility( entity, slot);
                if((int)abilityEntity < 0) continue;

                ref var baseCooldownComponent = ref _abilityAspect.BaseCooldown.Get((ProtoEntity)abilityEntity);
                baseCooldownComponent.Value = cooldown;

                _abilityAspect.RecalculateCooldown.GetOrAddComponent(abilityEntity);
                _abilityAspect.SetBaseCooldown.Del(entity);
            }
        }
    }
}