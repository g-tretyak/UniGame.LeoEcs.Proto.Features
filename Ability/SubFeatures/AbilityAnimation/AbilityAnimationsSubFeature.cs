namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilityAnimation
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// add critical animations if critical hit exist
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Game/Feature/Ability/AbilityAnimations SubFeature",fileName = "AbilityAnimations SubFeature")]
    public class AbilityAnimationsSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnCompleteAbilitySystems(IProtoSystems ecsSystems)
        {
            //clear ability animation when ability complete
            ecsSystems.Add(new ClearAbilityAnimationSystem());
            return UniTask.FromResult(ecsSystems);
        }
        
        public override UniTask<IProtoSystems> OnActivateSystems(IProtoSystems ecsSystems)
        {
            //reset ability animation to default when ability activated
            ecsSystems.Add(new AbilityResetDefaultAnimationOnActivateSystem());
            //select and activate animation options
            ecsSystems.Add(new AbilityActivateAnimationOptionsSystem());
            //reset all ability options when ability activated
            ecsSystems.Add(new AbilityResetAnimationOptionsSystem());
            return UniTask.FromResult(ecsSystems);
        }
        
        public override UniTask<IProtoSystems> OnEvaluateAbilitySystem(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new EvaluateAbilityAnimationSystem());
            return UniTask.FromResult(ecsSystems);
        }

    }
}