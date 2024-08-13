namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Behaviours
{
    using System;
    using Game.Code.Animations;
    using UnityEngine.AddressableAssets;

    [Serializable]
    public class AssetReferenceAnimationsSequence : AssetReferenceT<AnimationLink>
    {
        public AssetReferenceAnimationsSequence(string guid) : base(guid)
        {
        }
    }
}