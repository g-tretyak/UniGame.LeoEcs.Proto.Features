namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Behaviours
{
    using System;
    using Components;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class AttackRangeBehaviour : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
        {
            world.GetOrAddComponent<AttackRangeEffectComponent>(abilityEntity);
        }
    }
}