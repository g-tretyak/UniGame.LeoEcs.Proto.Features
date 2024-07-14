namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
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
    public sealed class ProcessApplyAbilityBySlotRequestSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<ApplyAbilityBySlotSelfRequest> _requestPool;
        private ProtoPool<AbilityMapComponent> _abilityMapPool;
        private ProtoPool<ApplyAbilitySelfRequest> _applyAbilitySelfRequestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<ApplyAbilityBySlotSelfRequest>()
                .Inc<AbilityMapComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var abilityMap = ref _abilityMapPool.Get(entity);
                ref var request = ref _requestPool.Get(entity);

                var slotId = request.AbilitySlot;
                if(slotId < 0 || slotId >= abilityMap.AbilityEntities.Count)
                    continue;
                
                ref var requestEntity = ref _applyAbilitySelfRequestPool.GetOrAddComponent(entity);
                requestEntity.Value = abilityMap.AbilityEntities[slotId];
            }
        }
    }
}