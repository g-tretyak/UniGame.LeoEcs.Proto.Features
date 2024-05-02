namespace UniGame.Ecs.Proto.Effects.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
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
    public sealed class DestroyEffectViewSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        private EffectAspect _effectAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<EffectViewComponent>()
                .Inc<DestroyEffectViewSelfRequest>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var view = ref _effectAspect.View.Get(entity);
                if (view.ViewInstance != null)
                {
                    view.ViewInstance.Despawn();
                }
                
                _world.DelEntity(entity);
            }
        }
    }
}