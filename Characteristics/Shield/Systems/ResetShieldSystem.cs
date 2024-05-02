namespace UniGame.Ecs.Proto.Characteristics.Shield.Systems
{
    using Base.Components.Events;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class ResetShieldSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<ShieldComponent>()
                .Inc<ResetCharacteristicsEvent>()
                .End();
        }
        
        public void Run()
        {
            var shieldPool = _world.GetPool<ShieldComponent>();
            
            foreach (var entity in _filter)
            {
                shieldPool.Del(entity);
            }
        }
    }
}