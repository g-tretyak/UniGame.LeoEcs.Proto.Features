namespace unigame.ecs.proto.GameEffects.ModificationEffect.Systems
{
    using Components;
    using Effects.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class ProcessDestroyedModificationEffectSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<EffectComponent>()
                .Inc<DestroyEffectSelfRequest>()
                .Inc<ModificationEffectComponent>()
                .End();
        }
        
        public void Run()
        {
            var effectPool = _world.GetPool<EffectComponent>();
            var modificationPool = _world.GetPool<ModificationEffectComponent>();
            
            foreach (var entity in _filter)
            {
                ref var effect = ref effectPool.Get(entity);
                ref var modification = ref modificationPool.Get(entity);
                
                if(!effect.Destination.Unpack(_world, out var destinationEntity))
                    continue;
                
                foreach (var modificationHandler in modification.ModificationHandlers)
                {
                    modificationHandler.RemoveModification(_world,entity, destinationEntity);
                }
            }
        }
    }
}