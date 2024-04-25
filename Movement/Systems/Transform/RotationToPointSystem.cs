namespace unigame.ecs.proto.Movement.Systems.Transform
{
    using System;
    using Aspect;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.Mathematics;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class RotationToPointSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        private NavigationAspect _navigationAspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<RotateToPointSelfRequest>()
                .Inc<TransformPositionComponent>()
                .Inc<TransformComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var transformComponent = ref _navigationAspect.Transform.Get(entity);
                ref var pointRequest = ref _navigationAspect.RotateTo.Get(entity);
                ref var positionComponent = ref _navigationAspect.Position.Get(entity);

                var transform = transformComponent.Value;
                
                if(transform == null) continue;
                
                var direction = math.normalize(pointRequest.Point - positionComponent.Position);

                if (_navigationAspect.ActiveGameView.Has(entity))
                {
                    ref var activeViewComponent = ref _navigationAspect.ActiveGameView.Get(entity);
                    if (activeViewComponent.Value.Unpack(_world, out var activeEntity))
                    {
                        ref var activeTransformComponent = ref _navigationAspect.Transform.Get(activeEntity);
                        transform = activeTransformComponent.Value;
                    }
                }
                
                if(transform == null) continue;
                
                transform.forward = direction;
            }
        }
    }
}