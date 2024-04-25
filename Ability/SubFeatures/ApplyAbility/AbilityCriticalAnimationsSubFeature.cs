namespace unigame.ecs.proto.Ability.SubFeatures.CriticalAnimations
{
    using System;
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;

    /// <summary>
    /// add critical animations if critical hit exist
    /// </summary>
    [Serializable]
    public class ApplyAbilitySubFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnActivateSystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
    }
}