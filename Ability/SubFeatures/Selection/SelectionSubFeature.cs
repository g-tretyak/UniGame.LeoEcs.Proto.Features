namespace UniGame.Ecs.Proto.Ability.SubFeatures.Selection
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
     
    using SubFeatures;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UserInput.Systems;

    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Ability/Selection SubFeature",fileName = "Selection SubFeature")]
    public sealed class SelectionSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnAfterInHandSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ClearSelectionForNonInHandAbilitySystem());
            ecsSystems.Add(new SelectTargetsSystem());
            return UniTask.FromResult(ecsSystems);
        }
    }
}