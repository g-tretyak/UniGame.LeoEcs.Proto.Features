namespace UniGame.Ecs.Proto.GameEffects.DamageEffect
{
    using Cysharp.Threading.Tasks;
    using Effects.Feature;
    using Leopotam.EcsProto;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Effects/Ability Radius Effect Feature")]
    public sealed class AbilityRadiusEffectFeature : EffectFeatureAsset
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {

            return UniTask.CompletedTask;
        }
    }
}