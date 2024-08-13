namespace UniGame.Ecs.Proto.Ability.SubFeatures.Self.Behaviours
{
    using System;
    using Ability.UserInput.Components;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class SelfApplyEffects : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
        {
            var pressPool = world.GetPool<CanApplyWhenUpInputComponent>();
            if (!pressPool.Has(abilityEntity))
                pressPool.Add(abilityEntity);
        }
    }
}