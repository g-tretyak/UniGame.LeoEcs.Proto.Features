namespace UniGame.Ecs.Proto.Movement.Systems.Rigidbody
{
    using Aspect;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Components;
    using UnityEngine;

    /// <summary>
    /// Система отвечающая за поворот во время пермещения через физическую систему Unity.
    /// </summary>
    public sealed class RigidbodyRotationSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private NavMeshAgentAspect _agentAspect;
        
        private ProtoIt _filter = It
            .Chain<RotationComponent>()
            .Inc<RigidbodyComponent>()
            .Inc<AngularSpeedComponent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var quaternionComponent = ref _agentAspect.Rotation.Get(entity);
                ref var rigidbodyComponent = ref _agentAspect.Rigidbody.Get(entity);
                ref var rotationSpeedComponent = ref _agentAspect.RotationSpeed.Get(entity);

                var rigidbody = rigidbodyComponent.Value;
                
                var previous = rigidbody.rotation;
                var current = quaternionComponent.Value;

                var rotationSpeed = rotationSpeedComponent.Value;
                var angle = Quaternion.Angle(previous, current);
                var rotationTime = rotationSpeed / angle;

                var lerpRotation = Quaternion.Lerp(previous, current, rotationTime * Time.deltaTime);
                
                rigidbody.MoveRotation(lerpRotation);
            }
        }
    }
}