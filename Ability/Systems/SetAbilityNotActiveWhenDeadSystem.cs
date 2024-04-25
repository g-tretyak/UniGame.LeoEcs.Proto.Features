namespace unigame.ecs.proto.Ability.Common.Systems
{
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class SetAbilityNotActiveWhenDeadSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<PrepareToDeathComponent>()
                .Inc<AbilityMapComponent>()
                .End();
        }
        
        public void Run()
        {
            var mapPool = _world.GetPool<AbilityMapComponent>();
            var activePool = _world.GetPool<ActiveAbilityComponent>();

            foreach (var entity in _filter)
            {
                ref var map = ref mapPool.Get(entity);
                foreach (var packedEntity in map.AbilityEntities)
                {
                    if(!packedEntity.Unpack(_world, out var abilityEntity))
                        continue;
                    
                    if(activePool.Has(abilityEntity))
                        activePool.Del(abilityEntity);
                }
            }
        }
    }
}