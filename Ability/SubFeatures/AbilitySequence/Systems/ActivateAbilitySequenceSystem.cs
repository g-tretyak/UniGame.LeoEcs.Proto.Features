namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySequence.Systems
{
    using System;
    using Aspects;
    using Components;
    using AbilitySequence;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

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
    public class ActivateAbilitySequenceSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _sequenceFilter;
        private EcsFilter _requestFilter;

        private AbilitySequenceAspect _aspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _requestFilter = _world
                .Filter<ActivateAbilitySequenceSelfRequest>()
                .Inc<AbilitySequenceReadyComponent>()
                .Inc<AbilitySequenceComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var sequenceEntity in _requestFilter)
            {
                //reset sequence data
                ref var sequenceComponent = ref _aspect.Sequence.Get(sequenceEntity);
                sequenceComponent.NextAbilityIndex = 0;
                sequenceComponent.Index = 0;
                sequenceComponent.ActiveAbility = -1;
                var abilities = sequenceComponent.Abilities;
                var count = abilities.Count;
                
                if(abilities.Count <= 0) continue;
                
                ref var activeComponent = ref _aspect.Active.GetOrAddComponent(sequenceEntity);
                ref var lastComponent = ref _aspect.Last.GetOrAddComponent(sequenceEntity);

                activeComponent.Value = abilities[0];
                lastComponent.Value = abilities[count-1];
                
                _aspect.ActivateNextInSequence.GetOrAddComponent(sequenceEntity);
            }
        }
    }
}