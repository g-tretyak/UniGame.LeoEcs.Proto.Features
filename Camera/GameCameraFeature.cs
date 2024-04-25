namespace unigame.ecs.proto.Camera
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Camera Feature", fileName = "Camera Feature")]
    public class GameCameraFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new CameraLookAtTargetSystem());
            return UniTask.CompletedTask;
        }
    }
}