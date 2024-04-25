namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySequence.Systems
{
    using System;
    using Aspects;
    using Common.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Wait next queued ability for launch
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class WaitToStartNextAbilitySystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        
        private EcsFilter _abilitySequenceFilter;
        private EcsFilter _eventFilter;
        
        private AbilitySequenceAspect _aspect;


        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            //take sequence target no processing abilities
            _eventFilter = _world
                .Filter<AbilityCompleteSelfEvent>()
                .Inc<OwnerComponent>()
                .End();

            _abilitySequenceFilter = _world
                .Filter<AbilitySequenceReadyComponent>()
                .Inc<AbilitySequenceActiveComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var abilityEntity in _eventFilter)
            {
                foreach (var sequenceEntity in _abilitySequenceFilter)
                {
                    ref var activeComponent = ref _aspect.Active.Get(sequenceEntity);
                    if(activeComponent.Value != abilityEntity) continue;
                    _aspect.ActivateNextInSequence.GetOrAddComponent(sequenceEntity);
                    
                    break;
                }
            }
        }
    }
}