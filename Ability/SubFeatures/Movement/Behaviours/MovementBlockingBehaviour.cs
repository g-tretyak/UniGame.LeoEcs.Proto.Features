namespace unigame.ecs.proto.Ability.SubFeatures.Movement.Behaviours
{
    using System;
    using Code.Configuration.Runtime.Ability.Description;
    using Components;
     
    using UnityEngine;

    [Serializable]
    public sealed class MovementBlockingBehaviour : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
        {
            var canBlockPool = world.GetPool<CanBlockMovementComponent>();
            canBlockPool.Add(abilityEntity);
        }

        public void DrawGizmos(GameObject target)
        {
        }
    }
}