namespace unigame.ecs.proto.Ability.Systems
{
    using System;
    using Aspects;
    using Common.Components;
    using Components.Requests;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Tools;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
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
    public class ActivateAbilitySystem : IProtoInitSystem, IProtoRunSystem
    {
        private AbilityTools _abilityTools;
        private ProtoWorld _world;

        private EcsFilter _abilityFilter;
        private EcsFilter _requestFilter;
        private AbilityAspect _abilityAspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _abilityTools = _world.GetGlobal<AbilityTools>();
            
            _requestFilter = _world
                .Filter<ActivateAbilityRequest>()
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
                ref var request = ref _abilityAspect.ActivateAbilityOnTarget.Get(requestEntity);
                if(!request.Target.Unpack(_world,out var targetEntity))
                    continue;

                if(!request.Ability.Unpack(_world,out var targetAbilityEntity))
                    continue;

                foreach (var abilityEntity in _abilityFilter)
                {
                    ref var ownerComponent = ref _abilityAspect.Owner.Get(abilityEntity);
                    if(!ownerComponent.Value.Unpack(_world,out _)) continue;
                    if (!ownerComponent.Value.EqualsTo(request.Target)) continue;
                    
                    if (!abilityEntity.Equals(targetAbilityEntity)) continue;
                    
                    _abilityTools.ActivateAbility(_world,targetEntity,abilityEntity);
                    
                    break;
                }
                
            }
        }
    }
}