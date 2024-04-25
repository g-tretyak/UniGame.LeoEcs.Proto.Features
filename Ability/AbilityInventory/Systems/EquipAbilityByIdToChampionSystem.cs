namespace unigame.ecs.proto.AbilityInventory.Systems
{
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// Search ability in inventory
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [ECSDI]
    public class EquipAbilityByIdToChampionSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private EcsFilter _championFilter;

        private ProtoPool<EquipAbilityIdToChampionRequest> _requestPool;
        private ProtoPool<EquipAbilityIdSelfRequest> _equipRequestPool;
        

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
			
            _filter = _world
                .Filter<EquipAbilityIdToChampionRequest>()
                .End();
            
            _championFilter = _world
                .Filter<ChampionComponent>()
                .End();

            _requestPool = _world.GetPool<EquipAbilityIdToChampionRequest>();
            _equipRequestPool = _world.GetPool<EquipAbilityIdSelfRequest>();
        }

        public void Run()
        {
            foreach (var request in _filter)
            {
                ref var requestComponent = ref _requestPool.Get(request);
				
                foreach (var entity in _championFilter)
                {
                    ref var abilityEquipRequest = ref _equipRequestPool.Add(request);
					
                    abilityEquipRequest.AbilityId = requestComponent.AbilityId;
                    abilityEquipRequest.AbilitySlot = requestComponent.AbilitySlot;
                    abilityEquipRequest.IsUserInput = requestComponent.IsUserInput;
                    abilityEquipRequest.IsDefault = requestComponent.IsDefault;
                    abilityEquipRequest.Owner = _world.PackEntity(entity);
					
                    _requestPool.Del(request);
                }
            }
        }
    }
}