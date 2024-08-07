namespace UniGame.Ecs.Proto.Characteristics.CriticalChance.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.Ecs.Proto.Characteristics.Base.Components.Requests;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// Converts critical chance data and applies it to the target game object in the ECS world.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
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
