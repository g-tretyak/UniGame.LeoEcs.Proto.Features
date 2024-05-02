namespace UniGame.Ecs.Proto.Characteristics.CriticalChance.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.Ecs.Proto.Characteristics.Base.Components.Requests;
     
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class CriticalChanceConverter : LeoEcsConverter
    {
        public float criticalChance;
        
        public float minLimitValue = 0f;
        public float maxLimitValue = 1000f;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var createCharacteristicRequest = ref world
                .GetOrAddComponent<CreateCharacteristicRequest<CriticalChanceComponent>>(entity);
            createCharacteristicRequest.Value = criticalChance;
            createCharacteristicRequest.MaxValue = maxLimitValue;
            createCharacteristicRequest.MinValue = minLimitValue;
            createCharacteristicRequest.Owner = entity.PackEntity(world);

            ref var criticalChanceComponent = ref world.GetOrAddComponent<CriticalChanceComponent>(entity);
        }
    }
}
