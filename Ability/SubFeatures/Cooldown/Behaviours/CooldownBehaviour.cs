namespace UniGame.Ecs.Proto.Ability.SubFeatures.Cooldown.Behaviours
{
    using System;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using LeoEcs.Shared.Extensions;
    using LeoEcs.Timer.Components;
    using Leopotam.EcsProto;

    [Serializable]
    public sealed class CooldownBehaviour : IAbilityBehaviour
    {
        public float cooldownValue;
        
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
        {
            ref var cooldownComponent = ref world.GetOrAddComponent<CooldownComponent>(abilityEntity);
            world.GetOrAddComponent<CooldownCompleteComponent>(abilityEntity);

            cooldownComponent.Value = cooldownValue;
        }
    }
}