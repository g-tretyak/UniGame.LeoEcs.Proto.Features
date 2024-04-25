namespace unigame.ecs.proto.Ability.SubFeatures.CriticalAnimations
{
    using System;
    using Cysharp.Threading.Tasks;
     
    using Movement.Systems;
    using Tools;
    using UnityEngine;

    /// <summary>
    /// add critical animations if critical hit exist
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Game/Feature/Ability/MovementBlockingAbility SubFeature",fileName = "MovementBlockingAbility SubFeature")]
    public class MovementBlockingAbilitySubFeature : AbilitySubFeature
    {

        public override UniTask<IProtoSystems> OnCompleteAbilitySystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new UnblockMovementSystem());
            return UniTask.FromResult(ecsSystems);
        }
        
        public override UniTask<IProtoSystems> OnActivateSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new BlockMovementSystem());
            return UniTask.FromResult(ecsSystems);
        }
        
        
    }
}