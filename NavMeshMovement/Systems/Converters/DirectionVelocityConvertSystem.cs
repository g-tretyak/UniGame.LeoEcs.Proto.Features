﻿namespace UniGame.Ecs.Proto.Movement.Systems.Converters
{
    using System;
    using Aspect;
    using Input.Components.Direction;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Система отвечающая за конвертацию map space направления в вектор скорости.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class DirectionVelocityConvertSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private NavMeshAspect _navigationAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<DirectionInputEvent>().End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var direction = ref _navigationAspect.Direction.Get(entity);
                ref var velocity = ref _navigationAspect.Velocity.Add(entity);
                
                velocity.Value = direction.Value;
            }
        }
    }
}