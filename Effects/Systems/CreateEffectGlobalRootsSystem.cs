namespace UniGame.Ecs.Proto.Effects.Systems
{
    using System;
    using Components;
    using Data;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

#if ENABLE_IL2CP
	using Unity.IL2CPP.CompilerServices;
	/// <summary>
	/// Assembling ability
	/// </summary>
	[Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class CreateEffectGlobalRootsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        private EffectGlobalAspect _effectGlobalAspect;
        private EffectsRootData _configuration;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _configuration = _world.GetGlobal<EffectsRootData>();
            
            _filter = _world
                .Filter<EffectGlobalRootMarkerComponent>()
                .End();
        }
        
        public void Run()
        {
            if(_filter.First() >= 0) return;
            
            var globalRoot = _world.NewEntity();
            ref var globalRootMarker = ref _effectGlobalAspect.Global.Add(globalRoot);
            ref var transforms = ref _effectGlobalAspect.Transforms.Add(globalRoot);
            ref var configuration = ref _effectGlobalAspect.Configuration.Add(globalRoot);

            transforms.Value = new Transform[_configuration.roots.Length];
            configuration.Value = _configuration;
        }
    }
}