namespace unigame.ecs.proto.Ability.SubFeatures
{
    using System;
    using Cysharp.Threading.Tasks;
     
    using Leopotam.EcsProto;
    using UnityEngine;

    [Serializable]
    public abstract class AbilitySubFeature : ScriptableObject
    {
        public virtual UniTask<IProtoSystems> OnInitializeSystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
        
        public virtual UniTask<IProtoSystems> OnStartSystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }

        public virtual UniTask<IProtoSystems> OnAfterInHandSystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
        
        
        public virtual UniTask<IProtoSystems> OnCompleteAbilitySystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
        
        public virtual UniTask<IProtoSystems> OnBeforeApplyAbility(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }

        public virtual UniTask<IProtoSystems> OnRevokeSystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }

        public virtual UniTask<IProtoSystems> OnUtilitySystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
        
        public virtual UniTask<IProtoSystems> OnActivateSystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
        
        public virtual UniTask<IProtoSystems> OnEvaluateAbilitySystem(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
        
        public virtual UniTask<IProtoSystems> OnPreparationApplyEffectsSystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }

        public virtual UniTask<IProtoSystems> OnApplyEffectsSystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
        
        public virtual UniTask<IProtoSystems> OnLastAbilitySystems(IProtoSystems ecsSystems)
        {
            return UniTask.FromResult(ecsSystems);
        }
    }
}