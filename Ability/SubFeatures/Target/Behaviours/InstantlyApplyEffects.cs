namespace unigame.ecs.proto.Ability.SubFeatures.Target.Behaviours
{
    using System;
    using Code.Configuration.Runtime.Ability.Description;
    using Components;
     
    using UnityEngine;

    [Serializable]
    public sealed class InstantlyApplyEffects : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
        {
            var instantlyPool = world.GetPool<CanInstantlyApplyEffects>();
            instantlyPool.Add(abilityEntity);
        }
    }
}