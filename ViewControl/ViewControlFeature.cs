namespace unigame.ecs.proto.ViewControl
{
    using Systems;
    using Components;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "Game/Feature/View Control Feature", fileName = "View Control Feature")]
    public sealed class ViewControlFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ProcessHideViewRequestSystem());
            ecsSystems.DelHere<HideViewRequest>();
            
            ecsSystems.Add(new ProcessShowViewRequestSystem());
            ecsSystems.DelHere<ShowViewRequest>();

            ecsSystems.Add(new ProcessDestroyedOwnerViewSystem());
            
            return UniTask.CompletedTask;
        }
    }
}