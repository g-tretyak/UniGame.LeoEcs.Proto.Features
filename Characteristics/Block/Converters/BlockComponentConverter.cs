namespace unigame.ecs.proto.Characteristics.Block.Converters
{
    using System;
    using System.Threading;
    using Components;
    using Leopotam.EcsProto;
    using unigame.ecs.proto.Characteristics.Base.Components.Requests;
     
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class BlockComponentConverter : LeoEcsConverter
    {
        public float block = 0f;
        
        [SerializeField] 
        [MaxValue(100)]
        public float maxDodge = 100f;
        [MinValue(0)]
        public float minDodge = 0f;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var createCharacteristicRequest = ref world.GetOrAddComponent<CreateCharacteristicRequest<BlockComponent>>(entity);
            createCharacteristicRequest.Value = block;
            createCharacteristicRequest.MaxValue = maxDodge;
            createCharacteristicRequest.MinValue = minDodge;
            createCharacteristicRequest.Owner = entity.PackEntity(world);
            
            ref var healthComponent = ref world.GetOrAddComponent<BlockComponent>(entity);
            healthComponent.Value = block;
            healthComponent.MaxValue = maxDodge;
            healthComponent.MinValue = minDodge;
        }
    }
}
