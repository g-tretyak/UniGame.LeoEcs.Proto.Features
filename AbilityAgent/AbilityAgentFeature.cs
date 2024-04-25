namespace unigame.ecs.proto.AbilityAgent
{
    using Cysharp.Threading.Tasks;
     
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Ability/Ability Agent Feature", fileName = "Ability Agent Feature")]
    public class AbilityAgentFeature : BaseLeoEcsFeature
    {
        public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new InitializeAbilityAgentSystem());
            ecsSystems.Add(new CreateAbilityAgentSystem());
        }
    }
}