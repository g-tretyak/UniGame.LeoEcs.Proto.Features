namespace unigame.ecs.proto.GameEffects.ModificationEffect
{
    using Systems;
    using Cysharp.Threading.Tasks;
    using Effects.Feature;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Effects/Modification Effect Feature")]
    public sealed class ModificationEffectFeature : EffectFeatureAsset
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ProcessDestroyedModificationEffectSystem());
            ecsSystems.Add(new ProcessRemoveModificationEffectSystem());
            ecsSystems.Add(new ProcessSingleModificationEffectSystem());
            ecsSystems.Add(new ProcessModificationEffectSystem());

            return UniTask.CompletedTask;
        }
    }
}