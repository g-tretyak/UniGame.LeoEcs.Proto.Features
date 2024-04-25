namespace unigame.ecs.proto.Gameplay.Death
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/Death")]
    public class DeathFeature  : BaseLeoEcsFeature
    {
        public override UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new CheckReadyToDeathSystem());
            
            //if unit ready to death then create KillRequest
            ecsSystems.Add(new DetectReadyToDeathByHealthSystem());
            ecsSystems.Add(new ProcessDeathAnimationSystem());
            ecsSystems.Add(new EvaluateDeathAnimationSystem());
            ecsSystems.Add(new CompleteDeathAnimationSystem());
            
            return UniTask.CompletedTask;
        }
    }
}
