namespace UniGame.Ecs.Proto.Movement.Systems.NavMesh
{
    using System;
    using Aspect;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
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
    public class MakeKinematicByRequestSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _rigidbodyFilter;

        private NavMeshAspect _navigationAspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _rigidbodyFilter = _world
                .Filter<RigidbodyComponent>()
                .Inc<SetKinematicSelfRequest>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _rigidbodyFilter)
            {
                ref var request = ref _navigationAspect.SetKinematicStatus.Get(entity);
                ref var navMeshAgentComponent = ref _navigationAspect.Rigidbody.Get(entity);
                navMeshAgentComponent.Value.isKinematic = request.Value;
                _navigationAspect.SetKinematicStatus.Del(entity);
            }
        }
    }
}