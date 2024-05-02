namespace UniGame.Ecs.Proto.Movement.Systems.NavMesh
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
    public sealed class RevokeComeToTheEndOfSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private NavMeshAspect _navigationAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world.Filter<ComePointComponent>()
                .Inc<RevokeComeToEndOfRequest>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                _navigationAspect.ComePoint.Del(entity);
                
                if(_navigationAspect.MovementTargetPoint.Has(entity))
                    _navigationAspect.MovementTargetPoint.Del(entity);
                
                if (!_navigationAspect.NavMeshAgentStop.Has(entity))
                    _navigationAspect.NavMeshAgentStop.Add(entity);
            }
        }
    }
}