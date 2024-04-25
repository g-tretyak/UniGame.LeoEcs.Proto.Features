namespace unigame.ecs.proto.Effects.Components
{
    using Data;
    using Game.Code.Configuration.Runtime.Effects;
    using UnityEngine.AddressableAssets;

    /// <summary>
    /// Отображение эффекта и длительность отображения.
    /// </summary>
    public struct EffectViewDataComponent
    {
        public AssetReferenceGameObject View;
        public float LifeTime;
        public ViewInstanceType ViewInstanceType;
        public bool UseEffectRoot;
        public EffectRootId EffectRoot;
        public bool AttachToSource;
    }
}