namespace UniGame.Ecs.Proto.Movement.Systems.Transform
{
    using System;
    using Aspect;
    using Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using Unity.Mathematics;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class RotationToPointSystem : IProtoRunSystem
    {
        private ProtoWorld _world;

        private NavMeshAspect _navigationAspect;
        
        private ProtoIt _filter = It
            .Chain<RotateToPointSelfRequest>()
            .Inc<TransformPositionComponent>()
            .Inc<TransformComponent>()
            .End();
        
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
                transform.forward = direction;
            }
        }
    }
}