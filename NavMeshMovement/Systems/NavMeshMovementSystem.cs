namespace UniGame.Ecs.Proto.Movement.Systems.NavMesh
{
    using System;
    using Aspect;
    using Components;
    using Game.Ecs.Core.Components;
    using Game.Ecs.Core.Death.Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// Система отвечающая за перемещение с помощью вектора скорости через систему NavMesh.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class NavMeshMovementSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private NavMeshAgentAspect _navigationAspect;

        private ProtoItExc _filter = It.Chain<VelocityComponent>()
            .Inc<NavMeshAgentComponent>()
            .Inc<AngularSpeedComponent>()
            .Inc<InstantRotateComponent>()
            .Exc<ImmobilityComponent>()
            .Exc<DisabledComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var velocityComponent = ref _navigationAspect.Velocity.Get(entity);
                ref var navMeshAgentComponent = ref _navigationAspect.Agent.Get(entity);
                ref var speedComponent = ref _navigationAspect.AgentSpeed.Get(entity);
                ref var rotationSpeedComponent = ref _navigationAspect.RotationSpeed.Get(entity);
                ref var instantRotateComponent = ref _navigationAspect.InstantRotate.Get(entity);

                var navMeshAgent = navMeshAgentComponent.Value;
                if (!navMeshAgent.enabled || !navMeshAgent.isOnNavMesh)
                    continue;

                if (instantRotateComponent.Value)
                {
                    var transform = navMeshAgent.transform;
                    var position = transform.position;
                    transform.LookAt(position + velocityComponent.Value);
                }

                navMeshAgent.speed = speedComponent.Value;
                navMeshAgent.angularSpeed = rotationSpeedComponent.Value;
                navMeshAgent.velocity = velocityComponent.Value * speedComponent.Value;
            }
        }
    }
}