namespace UniGame.Ecs.Proto.Ability.SubFeatures.Area
{
    using System;
    using Cysharp.Threading.Tasks;
    using Systems;
     
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Ability/AreaSubFeature",fileName = "AreaSubFeature")]
    public sealed class AreaSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnAfterInHandSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new RemoveAreaForNonHandAbilitySystem());
            ecsSystems.Add(new SetupAreaByJoystickSystem());
            return UniTask.FromResult(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnUtilitySystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new RotateToAreaSystem());
            return UniTask.FromResult(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnPreparationApplyEffectsSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new SelectTargetsForApplyEffectsSystem());
            return UniTask.FromResult(ecsSystems);
        }
    }
}