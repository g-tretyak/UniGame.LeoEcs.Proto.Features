namespace unigame.ecs.proto.Movement.Systems.NavMesh
{
    using System;
    using Aspect;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// disable navigation system
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SetNavigationStatusByRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;

        private NavigationAspect _navigationAspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<NavMeshAgentComponent>()
                .Inc<SetNavigationStatusSelfRequest>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var request = ref _navigationAspect.SetNavigationStatus.Get(entity);
                ref var navMeshAgentComponent = ref _navigationAspect.Agent.Get(entity);
                navMeshAgentComponent.Value.enabled = request.Value;
                
                _navigationAspect.SetNavigationStatus.Del(entity);
            }
        }
    }
}