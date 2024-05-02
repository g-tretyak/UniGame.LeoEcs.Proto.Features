namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Timer.Components;
    using UnityEngine;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class CooldownRevokeAbilityRequestSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<ApplyAbilitySelfRequest> _applyAbilityRequestPool;
        private ProtoPool<SetInHandAbilitySelfRequest> _setInHandAbilityRequestPool;
        private ProtoPool<CooldownStateComponent> _cooldownStatePool;
        private ProtoPool<CooldownComponent> _cooldownPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<SetInHandAbilitySelfRequest>()
                .Inc<ApplyAbilitySelfRequest>()
                .End();
        }
        
        public void Run()
        {
            foreach (var requestEntity in _filter)
            {
                ref var applyAbilityRequest = ref _applyAbilityRequestPool.Get(requestEntity);
                if(!applyAbilityRequest.Value.Unpack(_world,out var abilityEntity))
                    continue;
       
                ref var cooldownComponent = ref _cooldownPool.Get(abilityEntity);
                ref var cooldownStateComponent = ref _cooldownStatePool.Get(abilityEntity);
                
                var lastUseTime = cooldownStateComponent.LastTime;
                var nextUseTime = lastUseTime + cooldownComponent.Value;
                
                var remainTime = nextUseTime - Time.time;
                
                if (!(remainTime > 0.0f) || Mathf.Approximately(remainTime, 0.0f)) continue;
                
                _setInHandAbilityRequestPool.Del(requestEntity);
                _applyAbilityRequestPool.Del(requestEntity);
            }
        }
    }
}