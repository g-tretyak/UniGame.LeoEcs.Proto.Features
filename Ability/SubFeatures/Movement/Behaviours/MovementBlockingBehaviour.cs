namespace unigame.ecs.proto.Ability.SubFeatures.Movement.Behaviours
{
    using System;
    using Components;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class MovementBlockingBehaviour : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
        {
            var canBlockPool = world.GetPool<CanBlockMovementComponent>();
            canBlockPool.Add(abilityEntity);
        }

        public void DrawGizmos(GameObject target)
        {
        }
    }
}