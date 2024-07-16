namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Behaviours
{
    using System;
    using System.Collections.Generic;
    using Ability.Components;
    using Components;
    using Game.Code.Animations;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Tools;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// create animations options for critical strike
    /// </summary>
    [Serializable]
    public class CriticalAnimationsBehaviour : IAbilityBehaviour
    {
        public List<AnimationLink> animations = new();

        public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
        {
            var tools = world.GetGlobal<AbilityTools>();
            world.GetOrAddComponent<AbilityCriticalAnimationTargetComponent>(abilityEntity);
            
            foreach (var animation in animations)
            {
                var animationEntity = world.NewEntity();
                var packedAnimationEntity = world.PackEntity(animationEntity);
                ref var ownerComponent = ref world.AddComponent<OwnerComponent>(animationEntity);
                ref var criticalComponent = ref world.AddComponent<AbilityCriticalAnimationComponent>(animationEntity);
                ref var abilityAnimationComponent = ref world.AddComponent<AbilityAnimationComponent>(animationEntity);

                var ability = world.PackEntity(abilityEntity);
                ownerComponent.Value = ability;
                abilityAnimationComponent.Ability = ability;

                //build animation with milestones
                tools.ComposeAbilityAnimation(world,
                    ref ownerComponent.Value,
                    ref packedAnimationEntity,
                    animation);
            }
        }
    }
}