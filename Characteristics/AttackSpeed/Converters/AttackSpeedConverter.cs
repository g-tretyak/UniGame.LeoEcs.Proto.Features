namespace unigame.ecs.proto.Characteristics.AttackSpeed.Converters
{
    using System;
    using Components;
    using Cooldown;
    using Leopotam.EcsProto;
    using unigame.ecs.proto.Characteristics.Base.Components.Requests;
     
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class AttackSpeedConverter : LeoEcsConverter
    {
        public CooldownType cooldownType = CooldownType.Speed;
        public int abilitySlotId = 0;
        
        public float attackSpeed;
        public float minLimitValue = 0;
        public float maxLimitValue = 5;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var createCharacteristicRequest = ref world.GetOrAddComponent<CreateCharacteristicRequest<AttackSpeedComponent>>(entity);
            createCharacteristicRequest.Value = attackSpeed;
            createCharacteristicRequest.MaxValue = maxLimitValue;
            createCharacteristicRequest.MinValue = minLimitValue;
            createCharacteristicRequest.Owner = entity.PackEntity(world);

            ref var attackSpeedComponent = ref world.GetOrAddComponent<AttackSpeedComponent>(entity);
            ref var attackAbilityIdComponent = ref world.GetOrAddComponent<AttackAbilityIdComponent>(entity);
            ref var attackSpeedCooldownTypeComponent = ref world.GetOrAddComponent<AttackSpeedCooldownTypeComponent>(entity);
            attackSpeedCooldownTypeComponent.Value = cooldownType;
            attackAbilityIdComponent.Value = abilitySlotId;
        }
    }
}
