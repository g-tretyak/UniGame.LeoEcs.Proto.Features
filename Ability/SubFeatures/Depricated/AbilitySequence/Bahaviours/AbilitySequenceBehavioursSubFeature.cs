namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySequence
{
    using System;
    using Bahaviours.Systems;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// add critical animations if critical hit exist
    /// </summary>
    [Serializable]
    public class AbilitySequenceBehavioursSubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnActivateSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ActivateSequenceOnAbilityStartSystem());
            return UniTask.FromResult(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnLastAbilitySystems(IProtoSystems ecsSystems)
        {
            return base.OnLastAbilitySystems(ecsSystems);
        }
    }
}