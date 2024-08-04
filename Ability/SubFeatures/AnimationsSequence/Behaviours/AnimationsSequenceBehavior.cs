namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Behaviours
{
    using System;
    using System.Collections.Generic;
    using Ability.Aspects;
    using Ability.Components;
    using Abstract;
    using Components;
    using Cysharp.Threading.Tasks;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Tools;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// create animation sequence of animations
    /// </summary>
    [Serializable]
    public class AnimationsSequenceBehavior : IAbilityBehaviour
    {
        public List<AssetReferenceAnimationsSequence> animations = new List<AssetReferenceAnimationsSequence>();

        [SerializeReference]
        public IAbilityAnimationBehavior SequenceBehavior = new LinearAnimationSelectionBehavior();
        
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
        {
            //todo fix animation sequence usage for aspect
            // ref var counterComponent = ref world.GetOrAddComponent<AbilityAnimationVariantCounterComponent>(abilityEntity);
            // ref var variantsComponent = ref world.GetOrAddComponent<AbilityAnimationVariantsComponent>(abilityEntity);
            // ref var abilityOwnerComponent = ref world.GetComponent<OwnerComponent>(abilityEntity);
            //
            // counterComponent.Value = 0;
            //
            // SequenceBehavior.Compose(world, abilityEntity);
            //
            // foreach (var animation in animations)
            // {
            //     var animationEntity = world.NewEntity();
            //     var packedAnimationEntity = animationEntity.PackEntity(world);
            //     ref var ownerComponent = ref world.AddComponent<OwnerComponent>(animationEntity);
            //     ref var abilityAnimationComponent = ref world.AddComponent<AbilityAnimationComponent>(animationEntity);
            //     ref var animationVariantComponent = ref world.AddComponent<AbilityAnimationVariantComponent>(animationEntity);
            //
            //     var ability = world.PackEntity(abilityEntity);
            //     ownerComponent.Value = ability;
            //     abilityAnimationComponent.Ability = ability;
            //
            //     //build animation with milestones
            //     _tools.ComposeAbilityAnimationAsync(world,
            //             abilityOwnerComponent.Value,
            //             packedAnimationEntity,
            //             animation).Forget();
            //     
            //     variantsComponent.Variants.Add(packedAnimationEntity);
            // }
        }
    }
}