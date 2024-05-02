namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Behaviours
{
    using System;
    using AbilitySequence.Assets;
    using AbilitySequence.Bahaviours.Components;
    using AbilitySequence.Tools;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// create ability sequence entity
    /// </summary>
    [Serializable]
    public class AbilitySequenceBehaviour : IAbilityBehaviour
    {
        #region inspector

        [HideLabel]
        [InlineEditor]
        public AbilitySequenceAsset sequence;
        
        #endregion

        public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
        {
            var sequenceTools = world.GetGlobal<AbilitySequenceTools>();
            
#if UNITY_EDITOR
            if (!world.HasComponent<OwnerComponent>(abilityEntity))
            {

                Debug.LogError($"ERROR: NULL Owner for {nameof(AbilitySequenceBehaviour)} {sequence.name}");
                return;
            }
#endif

            var sequenceValue = sequence.sequence;
            ref var ownerComponent = ref world.GetComponent<OwnerComponent>(abilityEntity);

            var sequenceEntity = sequenceTools.CreateAbilitySequence(ref ownerComponent.Value,sequenceValue);

            var sequenceTriggerEntity = world.NewEntity();
            ref var triggerOwnerComponent = ref world.AddComponent<OwnerComponent>(sequenceTriggerEntity);
            ref var triggerComponent = ref world.AddComponent<ActivateSequenceTriggerComponent>(sequenceTriggerEntity);

            triggerOwnerComponent.Value = world.PackEntity(abilityEntity);
            triggerComponent.Trigger = abilityEntity;
            triggerComponent.Sequence = sequenceEntity;
        }
    }
}