namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySequence.Systems
{
    using System;
    using Ability.Aspects;
    using Ability.Tools;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// is sequence ability unequipped when try to equip it
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class CheckAbilitySequenceReadySystem : IProtoRunSystem
    {
        private AbilityAspect _tools;
        private AbilitySequenceAspect _sequence;
        private ProtoWorld _world;
        
        private ProtoIt _abilityFilter= It
            .Chain<AbilitySequenceComponent>()
            .Inc<AbilitySequenceAwaitComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _abilityFilter)
            {
                ref var dataComponent = ref _sequence.Sequence.Get(entity);
                ref var ownerComponent = ref _sequence.Owner.Get(entity);
                var isAllAbilitiesActive = true;
                
                foreach (var abilityEntity in dataComponent.Abilities)
                {
                    var active = _tools.IsActiveAbilityEntity(ref ownerComponent.Value, abilityEntity) > 0;
                    if(active) continue;
                    isAllAbilitiesActive = false;
                    break;
                }
                
                if(isAllAbilitiesActive) continue;
                
                _sequence.Await.Del(entity);
                _sequence.Ready.Add(entity);
            }
        }
    }
}