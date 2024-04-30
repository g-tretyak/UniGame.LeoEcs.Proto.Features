namespace unigame.ecs.proto.Movement.Systems.NavMesh
{
    using System;
    using Aspect;
    using Components;
    using Game.Ecs.Core.Death.Components;
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
    public sealed class StopNavMeshAgentSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private EcsFilter _deadFilter;
        
        private ProtoWorld _world;

        private NavigationAspect _navigationAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<NavMeshAgentComponent>()
                .Inc<DisabledComponent>()
                .End();
            
            _deadFilter = _world.Filter<NavMeshAgentComponent>()
                .Inc<DestroyComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                if(!_navigationAspect.NavMeshAgentStop.Has(entity))
                    _navigationAspect.NavMeshAgentStop.Add(entity);
            }
            
            foreach (var entity in _deadFilter)
            {
                if(!_navigationAspect.NavMeshAgentStop.Has(entity))
                    _navigationAspect.NavMeshAgentStop.Add(entity);
            }
        }
    }
}