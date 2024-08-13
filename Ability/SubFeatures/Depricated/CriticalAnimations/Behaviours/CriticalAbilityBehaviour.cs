namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Behaviours
{
    using System;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using UnityEngine;

    /// <summary>
    /// create animations options for critical strike
    /// </summary>
    [Serializable]
    public class CriticalAbilityBehaviour : IAbilityBehaviour
    {
        public AbilityId criticalAbilityId;

        public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
        {
            Debug.LogError("TODO CriticalAbilityBehaviour should be fixed");
//             ref var targetComponent = ref world.GetOrAddComponent<CriticalAbilityTargetComponent>(abilityEntity);
//             targetComponent.Value = criticalAbilityId;
//             
//             ref var ownerComponent = ref world.GetComponent<OwnerComponent>(abilityEntity);
//             if (!ownerComponent.Value.Unpack(world, out var ownerEntity))
//             {
// #if UNITY_EDITOR
//                 Debug.LogError($"CriticalAbilityBehaviour for {abilityEntity} owner entity {ownerEntity} not exists");
// #endif
//                 return;
//             }
//
//             world.GetOrAddComponent<CriticalAbilityOwnerComponent>(ownerEntity);
//             tools.EquipAbilityById(ref ownerComponent.Value, ref criticalAbilityId);
        }
    }
}