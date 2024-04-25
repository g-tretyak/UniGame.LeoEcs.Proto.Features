namespace unigame.ecs.proto.Characteristics.Cooldown
{
    using System;
    using Base.Modification;
    using Components;
     

    [Serializable]
    public sealed class CooldownModificationHandler : ModificationHandler
    {
        public override void AddModification(ProtoWorld world,int source, int destinationEntity)
        {
            var baseCooldownPool = world.GetPool<BaseCooldownComponent>();
            if(!baseCooldownPool.Has(destinationEntity))
                return;

            ref var baseCooldown = ref baseCooldownPool.Get(destinationEntity);
            baseCooldown.Modifications.AddModification(Modification);
            
            var requestPool = world.GetPool<RecalculateCooldownSelfRequest>();
            if (!requestPool.Has(destinationEntity))
                requestPool.Add(destinationEntity);
        }

        public override void RemoveModification(ProtoWorld world,int source, int destinationEntity)
        {
            var baseCooldownPool = world.GetPool<BaseCooldownComponent>();
            if(!baseCooldownPool.Has(destinationEntity))
                return;

            ref var baseCooldown = ref baseCooldownPool.Get(destinationEntity);
            baseCooldown.Modifications.RemoveModification(Modification);
            
            var requestPool = world.GetPool<RecalculateCooldownSelfRequest>();
            if (!requestPool.Has(destinationEntity))
                requestPool.Add(destinationEntity);
        }
    }
}