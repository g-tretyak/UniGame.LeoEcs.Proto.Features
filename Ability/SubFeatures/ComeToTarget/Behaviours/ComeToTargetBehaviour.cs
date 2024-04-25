namespace unigame.ecs.proto.Ability.SubFeatures.ComeToTarget.Behaviours
{
    using System;
    using Code.Configuration.Runtime.Ability.Description;
    using ComeToTarget.Components;
     
    using UnityEngine;

    [Serializable]
    public sealed class ComeToTargetBehaviour : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
        {
            var comeToPool = world.GetPool<CanComeToTargetComponent>();
            comeToPool.Add(abilityEntity);
        }
    }
}