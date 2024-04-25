namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySequence.Systems
{
    using System;
    using Ability.Aspects;
    using Aspects;
    using Common.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// activate ability sequence when it ready and request exist
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class CheckExecutionAbilitySequenceSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _sequenceFilter;
        private EcsFilter _eventFilter;
        
        private AbilitySequenceAspect _sequenceAspect;
        private AbilityAspect _abilityAspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _eventFilter = _world
                .Filter<AbilityStartUsingSelfEvent>()
                .Inc<OwnerComponent>()
                .End();
            
            _sequenceFilter = _world
                .Filter<AbilitySequenceComponent>()
                .Inc<AbilitySequenceActiveComponent>()
                .Inc<AbilitySequenceLastComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var abilityEntity in _eventFilter)
            {
                ref var abilityOwnerComponent = ref _abilityAspect.Owner.Get(abilityEntity);
                
                foreach (var sequenceEntity in _sequenceFilter)
                {
                    ref var sequenceOwnerComponent = ref _sequenceAspect.Owner.Get(sequenceEntity);
                    if(!sequenceOwnerComponent.Value.EqualsTo(abilityOwnerComponent.Value)) continue;
                    
                    ref var activeComponent = ref _sequenceAspect.Active.Get(sequenceEntity);
                    ref var lastComponent = ref _sequenceAspect.Last.Get(sequenceEntity);
                    
                    if(activeComponent.Value == abilityEntity && 
                       lastComponent.Value != abilityEntity)
                        continue;

                    _sequenceAspect.Complete.GetOrAddComponent(sequenceEntity);
                }
            }
        }
    }
}