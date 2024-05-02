namespace UniGame.Ecs.Proto.Characteristics.Speed.Converters
{
    using System;
    using Leopotam.EcsProto;
    using UniGame.Ecs.Proto.Characteristics.Base.Components.Requests;
    using UniGame.Ecs.Proto.Characteristics.Speed.Components;
     
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class SpeedConverter : LeoEcsConverter
    {
        public float speed = 5;

        [TitleGroup("Limits")]
        private bool overrideLimits = false;
        
        [ShowIf(nameof(overrideLimits))]
        [TitleGroup("Limits")]
        public float minValue;
        
        [TitleGroup("Limits")]
        [ShowIf(nameof(overrideLimits))]
        public float maxValue;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var createCharacteristicRequest = ref world.GetOrAddComponent<CreateCharacteristicRequest<SpeedComponent>>(entity);
            createCharacteristicRequest.Value = speed;
            createCharacteristicRequest.MaxValue = overrideLimits ? maxValue : 10000;
            createCharacteristicRequest.MinValue = overrideLimits ? minValue : 0;
            createCharacteristicRequest.Owner = entity.PackEntity(world);

            ref var speedComponent = ref world.GetOrAddComponent<SpeedComponent>(entity);
            speedComponent.Value = speed;
        }
    }
}
