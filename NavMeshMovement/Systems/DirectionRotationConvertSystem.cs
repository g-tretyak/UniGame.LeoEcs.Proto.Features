namespace UniGame.Ecs.Proto.Movement.Systems.Converters
{
    using System;
    using Aspect;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UnityEngine;

    /// <summary>
    /// Система отвечающая за конвертацию map space направления в квартенион направления.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class DirectionRotationConvertSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private NavMeshAgentAspect _agentAspect;
        
        private ProtoIt _filter = It
            .Chain<RotateToPointSelfRequest>()
            .Inc<RotationComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var direction = ref _agentAspect.RotateToPoint.Get(entity);
                ref var quaternion = ref _agentAspect.Rotation.Add(entity);
                
                quaternion.Value = Quaternion.LookRotation(direction.Point, Vector3.up);
            }
        }
    }
}