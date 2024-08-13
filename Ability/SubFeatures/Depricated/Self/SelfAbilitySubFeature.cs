namespace UniGame.Ecs.Proto.Ability.SubFeatures.Self
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class SelfAbilitySubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnApplyEffectsSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new SelfApplyAbilityEffectsSystem());
            return UniTask.FromResult(ecsSystems);
        }
    }
}