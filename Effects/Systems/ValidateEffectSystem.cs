﻿namespace UniGame.Ecs.Proto.Effects.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
#if ENABLE_IL2CP
	using Unity.IL2CPP.CompilerServices;
#endif
    
#if ENABLE_IL2CP
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ValidateEffectSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private EffectAspect _effectAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CreateEffectSelfRequest>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var request = ref _effectAspect.Create.Get(entity);
                if (!request.Destination.Unpack(_world, out _))
                    _effectAspect.Create.Del(entity);
            }
        }
    }
}