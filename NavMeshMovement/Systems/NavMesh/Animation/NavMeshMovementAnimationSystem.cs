﻿namespace UniGame.Ecs.Proto.Movement.Systems.NavMesh.Animation
{
    using System;
    using Characteristics.Speed.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class NavMeshMovementAnimationSystem : IProtoRunSystem, IProtoInitSystem
    {
        private static readonly int ForwardHash = Animator.StringToHash("Forward");
        private static readonly int TurnHash = Animator.StringToHash("Turn");

        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<SpeedComponent> _speedPool;
        private ProtoPool<AnimatorComponent> _animatorPool;
        private ProtoPool<TransformComponent> _transformPool;
        private ProtoPool<GroundInfoComponent> _groundInfoPool;
        private ProtoPool<NavMeshAgentComponent> _navMeshPool;
        private ProtoPool<MovementAnimationInfoComponent> _animationInfoPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<SpeedComponent>()
                .Inc<AnimatorComponent>()
                .Inc<TransformComponent>()
                .Inc<GroundInfoComponent>()
                .Inc<NavMeshAgentComponent>()
                .Inc<MovementAnimationInfoComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var speedComponent = ref _speedPool.Get(entity);
                var speed = speedComponent.Value;
                
                ref var transform = ref _transformPool.Get(entity);
                ref var groundInfo = ref _groundInfoPool.Get(entity);
                ref var navMeshAgent = ref _navMeshPool.Get(entity);
                ref var animationInfo = ref _animationInfoPool.Get(entity);
                ref var animatorComponent = ref _animatorPool.Get(entity);
                
                var animator = animatorComponent.Value;
                var controller = animator.runtimeAnimatorController;
                var agent = navMeshAgent.Value;
                
                if(agent.isOnNavMesh == false) continue;
                
                if (animator == null || !animator.isActiveAndEnabled) continue;
                var velocity = navMeshAgent.Value.velocity.normalized;
                velocity = transform.Value.InverseTransformDirection(velocity);
                velocity = Vector3.ProjectOnPlane(velocity, groundInfo.Normal);
                
                var agentVelocityMagnitude = agent.velocity.magnitude;
                var speedValue = (velocity.z * speed) / animationInfo.RunSpeed;
                var forwardAmount = agentVelocityMagnitude / speed;
                var turnAmount = Mathf.Atan2(velocity.x, velocity.z);

                animator.speed = speedValue > animationInfo.MaxRunSpeed
                    ? speedValue / animationInfo.MaxRunSpeed
                    : 1.0f;
                if(controller == null) continue;
                
                animator.SetFloat(ForwardHash, forwardAmount, 0.1f, Time.deltaTime);
                animator.SetFloat(TurnHash, turnAmount, 0.1f, Time.deltaTime);
            }
        }
    }
}