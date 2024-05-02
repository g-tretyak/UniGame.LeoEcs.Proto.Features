namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Movement.Systems;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// add critical animations if critical hit exist
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Ability/MovementBlockingAbility SubFeature",
        fileName = "MovementBlockingAbility SubFeature")]
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