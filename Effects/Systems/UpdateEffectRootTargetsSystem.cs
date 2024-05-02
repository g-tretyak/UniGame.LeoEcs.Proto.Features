namespace UniGame.Ecs.Proto.Effects.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Show view effect by effect data
    /// </summary>
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
    public sealed class UpdateEffectRootTargetsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private EffectAspect _effectAspect;
        private EffectViewAspect _effectViewAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<EffectAppliedSelfEvent>()
                .Inc<EffectRootTransformsComponent>()
                .End();
        }
        
        //Todo: System is empty 
        public void Run()
        {
            foreach (var entity in _filter)
            {
                
            }
        }
    }
}