namespace UniGame.Ecs.Proto.Movement.Systems
{
    using System;
    using Aspect;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
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
    public sealed class ProcessImmobilityStatusSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private EcsFilter _stopFilter;
        
        private ProtoWorld _world;

        private NavMeshAspect _navigationAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<ImmobilityComponent>().End();
            _stopFilter = _world.Filter<ImmobilityComponent>()
                .Inc<NavMeshAgentComponent>()
                .Exc<MovementStopSelfRequest>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var block = ref _navigationAspect.Immobility.Get(entity);
                if (block.BlockSourceCounter <= 0)
                    _navigationAspect.Immobility.Del(entity);
            }
            
            foreach (var entity in _stopFilter)
            {
                if(_navigationAspect.NavMeshAgentStop.Has(entity))
                    continue;

                _navigationAspect.NavMeshAgentStop.Add(entity);
            }
        }
    }
}