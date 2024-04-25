namespace unigame.ecs.proto.GameEffects.DamageEffect
{
    using Cysharp.Threading.Tasks;
    using Effects.Feature;
    using Leopotam.EcsProto;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Effects/Damage Effect Feature")]
    public sealed class BlockEffectFeature : EffectFeatureAsset
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            return UniTask.CompletedTask;
        }
    }
}