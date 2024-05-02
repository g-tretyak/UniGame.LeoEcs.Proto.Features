namespace UniGame.Ecs.Proto.Characteristics.Duration
{
    using System;
    using Base.Modification;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    [Serializable]
    public sealed class DurationModificationHandler : ModificationHandler
    {
        public override void AddModification(ProtoWorld world,ProtoEntity source, ProtoEntity destinationEntity)
        {
            var baseDurationPool = world.GetPool<BaseDurationComponent>();
            if(!baseDurationPool.Has(destinationEntity))
                return;

            ref var baseDuration = ref baseDurationPool.Get(destinationEntity);
            baseDuration.Modifications.AddModification(Modification);
            
            var requestPool = world.GetPool<RecalculateDurationRequest>();
            if (!requestPool.Has(destinationEntity))
                requestPool.Add(destinationEntity);
        }

        public override void RemoveModification(ProtoWorld world,ProtoEntity source, ProtoEntity destinationEntity)
        {
            var baseDurationPool = world.GetPool<BaseDurationComponent>();
            if(!baseDurationPool.Has(destinationEntity))
                return;

            ref var baseDuration = ref baseDurationPool.Get(destinationEntity);
            baseDuration.Modifications.RemoveModification(Modification);
            
            var requestPool = world.GetPool<RecalculateDurationRequest>();
            if (!requestPool.Has(destinationEntity))
                requestPool.Add(destinationEntity);
        }
    }
}