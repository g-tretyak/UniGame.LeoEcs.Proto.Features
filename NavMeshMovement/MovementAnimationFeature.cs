namespace unigame.ecs.proto.Movement
{
    using Systems.NavMesh.Animation;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Movement/Movement Animation Feature", 
        fileName = "Movement Animation Feature")]
    public sealed class MovementAnimationFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new NavMeshMovementAnimationSystem());
            return UniTask.CompletedTask;
        }
    }
}