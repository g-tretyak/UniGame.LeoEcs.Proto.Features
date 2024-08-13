namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Systems
{
    using System;
    using Ability.Aspects;
    using Aspects;
    using Common.Components;
    using Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// if critical hit exist - add critical animations
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class ActivateCriticalAbilitySystem : IProtoRunSystem
    {
        private AbilityAspect _abilityTools;
        private ProtoWorld _world;
        private CriticalAnimationsAspect _aspect;
        
        private ProtoIt _filter= It
            .Chain<ApplyAbilitySelfRequest>()
            .Inc<CriticalAbilityOwnerComponent>()
            .End();


        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var request = ref _aspect.ApplyAbilitySelfRequest.Get(entity);
                if(!request.Value.Unpack(_world,out var abilityEntity))
                    continue;

                var hasAbilityTarget = _aspect.CriticalAbilityTarget.Has(abilityEntity);
                if(!hasAbilityTarget) continue;
                
                var hasCriticalAttackMarker = _aspect.CriticalAttackMarker.Has(entity);
                if(!hasCriticalAttackMarker) continue;
                
                ref var ownerComponent = ref _aspect.Owner.Get(abilityEntity);
                ref var abilityTargetComponent = ref _aspect.CriticalAbilityTarget.Get(abilityEntity);
                
                if(!_abilityTools.TryGetAbilityById(ref ownerComponent.Value,
                       abilityTargetComponent.Value,out var criticalAbilityEntity))
                    continue;
                
                //reset current auto cooldown
                //mark current auto as completed
                ref var completeRequest = ref _aspect.CompleteAbilitySelfRequest.GetOrAddComponent(abilityEntity);
                ref var restartAbilityCooldown = ref _aspect.RestartAbilityCooldownSelfRequest.GetOrAddComponent(abilityEntity);
                //ef var targetsComponent = ref _aspect.AbilityTargets.GetOrAddComponent(abilityEntity);
                ref var resetAbilityCooldown = ref _aspect.ResetAbilityCooldownSelfRequest.GetOrAddComponent(criticalAbilityEntity);
                
                //activate critical ability with targets from current auto
                //_targetTools.ActivateAbilityWithTargets(entity,criticalAbilityEntity,targetsComponent.Entities);
            }
        }
    }
}