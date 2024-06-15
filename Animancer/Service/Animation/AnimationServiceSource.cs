using Cysharp.Threading.Tasks;
using Game.Code.Services.Animation.Data.AnimnationsData;
using UniGame.AddressableTools.Runtime;
using UniGame.Core.Runtime;
using UniGame.GameFlow.Runtime.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;

namespace Game.Code.Services.Animation
{
    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
    [CreateAssetMenu(menuName = "Gameplay/Services/AnimationService Source", fileName = "AnimationService Source")]
    public class AnimationServiceSource : DataSourceAsset<IAnimationService>
    {
        [FormerlySerializedAs("animationsDataAsset")]
        public AssetReferenceT<AnimationsDataAsset> AnimationsDataAsset;
        protected override async UniTask<IAnimationService> CreateInternalAsync(IContext context)
        {
            var animationsDataAsset =
                await AnimationsDataAsset.LoadAssetTaskAsync(context.LifeTime);
            return new AnimationService(animationsDataAsset.Data);
        }
    }
}