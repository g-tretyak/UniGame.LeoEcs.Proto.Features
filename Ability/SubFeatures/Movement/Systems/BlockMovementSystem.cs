namespace unigame.ecs.proto.Ability.SubFeatures.Movement.Systems
{
    using System;
    using Common.Components;
    using Components;
    using Core.Components;
    using Ecs.Movement.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class BlockMovementSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<OwnerComponent> ownerPool;
        private ProtoPool<ImmobilityComponent> blockPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<CanBlockMovementComponent>()
                .Inc<OwnerComponent>()
                .Inc<AbilityStartUsingSelfEvent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var owner = ref ownerPool.Get(entity);
                if(!owner.Value.Unpack(_world, out var ownerEntity))
                    continue;

                ref var block = ref blockPool.GetOrAddComponent(ownerEntity);
                block.BlockSourceCounter++;
            }
        }
    }
}