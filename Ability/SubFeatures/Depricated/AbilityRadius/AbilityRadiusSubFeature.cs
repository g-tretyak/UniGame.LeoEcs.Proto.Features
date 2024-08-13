namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilityAnimation
{
    using System;
    using Common.Systems;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// add critical animations if critical hit exist
    /// </summary>
    [Serializable]
    public class AbilityRadiusSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnInitializeSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.AddSystem(new ApplyAbilityRadiusSystem());
            return base.OnInitializeSystems(ecsSystems);
        }
    }
}