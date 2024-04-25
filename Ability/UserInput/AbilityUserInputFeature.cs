namespace unigame.ecs.proto.Ability.UserInput
{
    using System;
    using Systems;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    [CreateAssetMenu(menuName = "Game/Feature/Ability/Ability Input Feature", 
        fileName = "Ability Input Feature")]
    public sealed class AbilityUserInputFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ProcessAbilityUpInputSystem());
            ecsSystems.Add(new RestoreDefaultInHandAbilitySystem());
            ecsSystems.Add(new ClearActiveTimeSystem());

            return UniTask.CompletedTask;
        }
    }
}