namespace UniGame.Ecs.Proto.Ability.SubFeatures.ComeToTarget.Behaviours
{
    using System;
    using ComeToTarget.Components;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class ComeToTargetBehaviour : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
        {
            var comeToPool = world.GetPool<CanComeToTargetComponent>();
            comeToPool.Add(abilityEntity);
        }
    }
}