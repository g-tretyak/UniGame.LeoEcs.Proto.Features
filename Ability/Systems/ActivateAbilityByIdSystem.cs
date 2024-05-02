namespace UniGame.Ecs.Proto.Ability.Systems
{
    using System;
    using Common.Components;
    using Components.Requests;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Tools;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// Activate ability by id
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class ActivateAbilityByIdSystem : IProtoInitSystem, IProtoRunSystem
    {
        private AbilityTools _abilityTools;
        private ProtoWorld _world;

        private EcsFilter _abilityFilter;
        private EcsFilter _requestFilter;

        private ProtoPool<OwnerComponent> _ownerPool;
        private ProtoPool<AbilityIdComponent> _abilityIdPool;
        private ProtoPool<ActivateAbilityByIdRequest> _activateRequestPool;
        private ProtoPool<ActivateAbilityRequest> _activateAbilityRequestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _abilityTools = _world.GetGlobal<AbilityTools>();
            
            _requestFilter = _world
                .Filter<ActivateAbilityByIdRequest>()
                .End();

            _abilityFilter = _world
                .Filter<ActiveAbilityComponent>()
                .Inc<AbilityIdComponent>()
                .Inc<OwnerComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var requestEntity in _requestFilter)
            {
                ref var request = ref _activateRequestPool.Get(requestEntity);
                if(!request.Target.Unpack(_world,out var targetEntity)) continue;

                foreach (var abilityEntity in _abilityFilter)
                {
                    ref var ownerComponent = ref _ownerPool.Get(abilityEntity);
                    if (!ownerComponent.Value.EqualsTo(request.Target)) continue;
                    
                    ref var abilityId = ref _abilityIdPool.Get(abilityEntity);
                    if (abilityId.AbilityId != request.AbilityId) continue;

                    ref var activateRequest = ref _activateAbilityRequestPool.GetOrAddComponent(requestEntity);
                    activateRequest.Ability = _world.PackEntity(abilityEntity);
                    activateRequest.Target = request.Target;
                    
                    break;
                }
                
            }
        }
    }
}