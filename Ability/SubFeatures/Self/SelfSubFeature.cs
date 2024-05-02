namespace UniGame.Ecs.Proto.Ability.SubFeatures.Self
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    [CreateAssetMenu(menuName = "Game/Feature/Ability/Self SubFeature",fileName = "Self SubFeature")]
    public sealed class SelfSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnApplyEffectsSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new SelfApplyAbilityEffectsSystem());
            return UniTask.FromResult(ecsSystems);
        }
    }
}