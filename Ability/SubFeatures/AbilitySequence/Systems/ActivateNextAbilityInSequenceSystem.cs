﻿namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySequence.Systems
{
    using System;
    using Aspects;
    using Components;
    using AbilitySequence;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.Ecs.Proto.Ability.Tools;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// activate next ability in queue
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class ActivateNextAbilityInSequenceSystem : IProtoInitSystem, IProtoRunSystem
    {
        private AbilityTools _abilityTools;
        private ProtoWorld _world;
        private EcsFilter _requestFilter;
        
        private AbilitySequenceAspect _aspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _abilityTools = _world.GetGlobal<AbilityTools>();
            
            _requestFilter = _world
                .Filter<ActivateNextAbilityInSequenceSelfRequest>()
                .Inc<AbilitySequenceComponent>()
                .Inc<AbilitySequenceReadyComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _requestFilter)
            {
                ref var dataComponent = ref _aspect.Sequence.Get(entity);

                var nextAbilityIndex = dataComponent.NextAbilityIndex;
                var abilities = dataComponent.Abilities;
                nextAbilityIndex = nextAbilityIndex < 0 ? 0 : nextAbilityIndex;
                nextAbilityIndex = nextAbilityIndex >= abilities.Count ? 0 : nextAbilityIndex;

                var activeAbility = nextAbilityIndex;
                var nextAbility = nextAbilityIndex + 1;
                var activeAbilityEntity = abilities[activeAbility];

                dataComponent.Index = activeAbility;
                dataComponent.NextAbilityIndex = nextAbility;
                dataComponent.ActiveAbility = (int)activeAbilityEntity;

                ref var abilityOwner = ref _aspect.Owner.Get(activeAbilityEntity);
                abilityOwner.Value.Unpack(_world, out var ownerEntity);

                ref var activeComponent =  ref _aspect.Active.GetOrAddComponent(entity);
                activeComponent.Value = activeAbilityEntity;
                
                _abilityTools.ActivateAbility(_world,ownerEntity,activeAbilityEntity);
            }
        }
    }
}