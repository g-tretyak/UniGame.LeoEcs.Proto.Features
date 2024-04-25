namespace unigame.ecs.proto.Ability.SubFeatures.Target.Behaviours
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class AttackRangeBehaviour : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
        {
            world.GetOrAddComponent<AttackRangeEffectComponent>(abilityEntity);
        }
    }
}