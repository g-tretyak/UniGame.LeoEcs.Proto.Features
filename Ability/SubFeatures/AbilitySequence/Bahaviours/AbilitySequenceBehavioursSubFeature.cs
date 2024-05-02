namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySequence
{
    using System;
    using Bahaviours.Systems;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// add critical animations if critical hit exist
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Ability/Ability Sequence Behaviours SubFeature",fileName = "Ability Sequence Behaviours SubFeature")]
    public class AbilitySequenceBehavioursSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnActivateSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ActivateSequenceOnAbilityStartSystem());
            return UniTask.FromResult(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnLastAbilitySystems(IProtoSystems ecsSystems)
        {
            return base.OnLastAbilitySystems(ecsSystems);
        }
    }
}