namespace UniGame.Ecs.Proto.GameEffects.DamageEffect
{
    using Systems;
    using Cysharp.Threading.Tasks;
    using Effects.Feature;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Effects/Damage Effect Feature")]
    public sealed class DamageEffectFeature : EffectFeatureAsset
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ProcessDamageEffectSystem());
            ecsSystems.Add(new ProcessAttackDamageEffectSystem());
            ecsSystems.Add(new ProcessSplashAttackDamageEffectSystem());

            return UniTask.CompletedTask;
        }
    }
}