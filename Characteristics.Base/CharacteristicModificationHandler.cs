namespace unigame.ecs.proto.Characteristics.Base
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
        public override void AddModification(ProtoWorld world,int sourceEntity, int destinationEntity)
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
            request.ModificationSource = world.PackedEntity(sourceEntity);
            request.Target = world.PackedEntity(destinationEntity);
            request.Modification = modification;
        }

        public override void RemoveModification(ProtoWorld world,int source, int destinationEntity)
        {
            if(!world.HasComponent<TCharacteristic>(destinationEntity))
                return;
            
            var entity = world.NewEntity();
            ref var removeRequest = ref world
                .AddComponent<RemoveCharacteristicModificationRequest<TCharacteristic>>(entity);
            removeRequest.Source = world.PackedEntity(source);
            removeRequest.Target = world.PackedEntity(destinationEntity);
        }
    }
}