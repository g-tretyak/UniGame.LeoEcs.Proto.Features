﻿namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ProcessApplyAbilityBySlotRequestSystem : IProtoRunSystem
    {
        private ProtoIt  _filter = It
            .Chain<ApplyAbilityBySlotSelfRequest>()
            .Inc<AbilityMapComponent>()
            .End();

        private AbilityAspect _abilityAspect;
        private ProtoWorld _world;
        
        private ProtoPool<ApplyAbilityBySlotSelfRequest> _requestPool;
        private ProtoPool<AbilityMapComponent> _abilityMapPool;
        private ProtoPool<ApplyAbilitySelfRequest> _applyAbilitySelfRequestPool;
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var request = ref _requestPool.Get(entity);
                var slotId = request.AbilitySlot;
                
                var packedAbility = _abilityAspect.GetAbilityBySlot(entity, slotId);
                if(!packedAbility.Unpack(_world, out var abilityEntity))
                    continue;
                ref var requestEntity = ref _applyAbilitySelfRequestPool.GetOrAddComponent(entity);
                requestEntity.Value = packedAbility;
            }
        }
    }
}