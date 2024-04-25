namespace unigame.ecs.proto.Ability.SubFeatures.CriticalAnimations
{
    using System;
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
     
    using Systems;
    using UnityEngine;

    /// <summary>
    /// add critical animations if critical hit exist
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Game/Feature/Ability/Ability Animations Options SubFeature",fileName = "Ability Animations Options SubFeature")]
    public class AbilityAnimationsSequenceSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnActivateSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new SelectLinearAnimationVariantSystem());
            ecsSystems.Add(new UpdateAnimationsVariantCounterSystem());

            return UniTask.FromResult(ecsSystems);
        }
    }
}