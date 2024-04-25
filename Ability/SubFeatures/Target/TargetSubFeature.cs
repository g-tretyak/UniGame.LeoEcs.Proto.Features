namespace unigame.ecs.proto.Ability.SubFeatures.Target
{
    using System;
    using System.Collections.Generic;
    using Systems;
    using Components;
    using Cysharp.Threading.Tasks;
     
    using Leopotam.EcsLite.ExtendedSystems;
    using SubFeatures;
    using Tools;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UserInput.Systems;

    [Serializable]
    [CreateAssetMenu(menuName = "Game/Feature/Ability/Target SubFeature",fileName = "Target SubFeature")]
    public sealed class TargetSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnAfterInHandSystems(IProtoSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            var targetTools = new AbilityTargetTools();
            world.SetGlobal(targetTools);
            
            ecsSystems.Add(targetTools);
            ecsSystems.Add(new ClearTargetsForNonInHandAbilitySystem());
            ecsSystems.Add(new DefaultAbilitySelectTargetSystem());
            ecsSystems.Add(new SelectTargetByJoystickSystem());
            ecsSystems.Add(new RemoveUntargetableTargetSystem());
            ecsSystems.Add(new RectangleZoneDetectionSystem());
            ecsSystems.Add(new CircleZoneDetectionSystem());
            ecsSystems.Add(new ConeZoneDetectionSystem());
            ecsSystems.Add(new SelectTargetsSystem());
            ecsSystems.Add(new ProcessEmptyTargetSystem());
            ecsSystems.Add(new CleanupUnderTargetSystem());
            ecsSystems.Add(new ProcessTargetsSystem());
            ecsSystems.Add(new RemoveZeroUnderTargetSystem());
            
            return UniTask.FromResult(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnRevokeSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.DelHere<AbilityTargetsOutsideEvent>();
            ecsSystems.Add(new TargetsOutsideRadiusRevokeAbilitySystem());
            return UniTask.FromResult(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnUtilitySystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new RotateToTargetSystem());
            return UniTask.FromResult(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnApplyEffectsSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new InstantlyApplyAbilityEffectsSystem());
            ecsSystems.Add(new SplashApplyEffectsSystem());
            
            return UniTask.FromResult(ecsSystems);
        }
    }
}