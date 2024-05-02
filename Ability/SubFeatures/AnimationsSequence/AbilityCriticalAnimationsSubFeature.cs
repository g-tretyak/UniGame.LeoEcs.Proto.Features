namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations
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
    [CreateAssetMenu(menuName = "Proto Features/Ability/Ability Animations Options SubFeature",fileName = "Ability Animations Options SubFeature")]
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