namespace UniGame.Ecs.Proto.Characteristics.Base
{
    using System;
    using Components;
    using Components.Requests.OwnerRequests;
    using Leopotam.EcsProto;
    using Modification;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public abstract class CharacteristicModificationHandler<TCharacteristic> : ModificationHandler
        where TCharacteristic : struct
    {
        public override void AddModification(ProtoWorld world,ProtoEntity sourceEntity, ProtoEntity destinationEntity)
        {
            if(!world.HasComponent<CharacteristicComponent<TCharacteristic>>(destinationEntity))
                return;

            var modification = new Modification.Modification()
            {
                counter = 1,
                allowedSummation = allowedSummation,
                isPercent = isPercent,
                baseValue = value,
                isMaxLimitModification = isMaxLimitModification,
            };
            
            var entity = world.NewEntity();
            ref var request = ref world.AddComponent<AddModificationRequest<TCharacteristic>>(entity);
            request.ModificationSource = sourceEntity.PackEntity(world);
            request.Target = destinationEntity.PackEntity(world);
            request.Modification = modification;
        }

        public override void RemoveModification(ProtoWorld world,ProtoEntity source, ProtoEntity destinationEntity)
        {
            if(!world.HasComponent<TCharacteristic>(destinationEntity))
                return;
            
            var entity = world.NewEntity();
            ref var removeRequest = ref world
                .AddComponent<RemoveCharacteristicModificationRequest<TCharacteristic>>(entity);
            removeRequest.Source = source.PackEntity(world);
            removeRequest.Target = destinationEntity.PackEntity(world);
        }
    }
}