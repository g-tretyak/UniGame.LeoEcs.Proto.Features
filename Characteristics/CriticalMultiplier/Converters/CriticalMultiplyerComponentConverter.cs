namespace unigame.ecs.proto.Characteristics.CriticalMultiplier.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using unigame.ecs.proto.Characteristics.Base.Components.Requests;
     
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class CriticalMultiplierConverter : LeoEcsConverter
    {
        public float criticalMultilplier = 100;
        
        public float minLimitValue = 0f;
        public float maxLimitValue = 1000f;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var createCharacteristicRequest = ref world
                .GetOrAddComponent<CreateCharacteristicRequest<CriticalMultiplierComponent>>(entity);
            createCharacteristicRequest.Value = criticalMultilplier;
            createCharacteristicRequest.MaxValue = maxLimitValue;
            createCharacteristicRequest.MinValue = minLimitValue;
            createCharacteristicRequest.Owner = entity.PackEntity(world);

            ref var valueComponent = ref world.GetOrAddComponent<CriticalMultiplierComponent>(entity);
            valueComponent.Value = criticalMultilplier;
        }
    }
}
