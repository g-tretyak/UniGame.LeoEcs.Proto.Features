namespace UniGame.Ecs.Proto.GameEffects.HealingEffect
{
    using Systems;
    using Cysharp.Threading.Tasks;
    using Effects.Feature;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Proto Features/Effects/Healing Effect Feature")]
    public sealed class HealingEffectFeature : EffectFeatureAsset
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ProcessHealingEffectSystem());
            
            return UniTask.CompletedTask;
        }
    }
}