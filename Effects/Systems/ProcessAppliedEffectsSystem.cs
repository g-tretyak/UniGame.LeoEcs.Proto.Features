namespace unigame.ecs.proto.Effects.Systems
{
    using Aspects;
    using Components;
     
    using System;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
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
    public sealed class ProcessAppliedEffectsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        private EffectAspect _effectAspect;
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<ApplyEffectSelfRequest>()
                .Exc<DestroyEffectSelfRequest>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                _effectAspect.EffectAppliedSelfEvent.Add(entity);
            }
        }
    }
}