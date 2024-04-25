namespace unigame.ecs.proto.Movement.Systems.Converters
{
    using System;
    using Aspect;
    using Components;
    using Input.Components.Direction;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Система отвечающая за конвертацию остановки пользовательского ввода в запрос остановки движения entity через NavMesh.
    /// </summary>
    #if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class EndInputStopNavMeshAgentConvertSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private NavigationAspect _navigationAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<EndDirectionInputEvent>()
                .Inc<NavMeshAgentComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                if(!_navigationAspect.NavMeshAgentStop.Has(entity))
                    _navigationAspect.NavMeshAgentStop.Add(entity);
            }
        }
    }
}