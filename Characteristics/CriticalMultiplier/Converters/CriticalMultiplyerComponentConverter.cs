namespace UniGame.Ecs.Proto.Characteristics.CriticalMultiplier.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.Ecs.Proto.Characteristics.Base.Components.Requests;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// Converts critical multiplier data and applies it to the target game object in the ECS world.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class CriticalMultiplierConverter : LeoEcsConverter
    {
        public float criticalMultiplier = 100;
        
        public float minLimitValue = 0f;
        public float maxLimitValue = 1000f;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var createCharacteristicRequest = ref world
                .GetOrAddComponent<CreateCharacteristicRequest<CriticalMultiplierComponent>>(entity);
            createCharacteristicRequest.Value = criticalMultiplier;
            createCharacteristicRequest.MaxValue = maxLimitValue;
            createCharacteristicRequest.MinValue = minLimitValue;
            createCharacteristicRequest.Owner = entity.PackEntity(world);

            ref var valueComponent = ref world.GetOrAddComponent<CriticalMultiplierComponent>(entity);
            valueComponent.Value = criticalMultiplier;
        }
    }
}
