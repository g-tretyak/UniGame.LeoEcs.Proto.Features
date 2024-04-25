namespace unigame.ecs.proto.Effects.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// select parent for effect by view instance type
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
    public sealed class SelectAvatarParentTargetsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private EffectAspect _effectAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<EffectAppliedSelfEvent>()
                .Inc<EffectViewDataComponent>()
                .Exc<EffectParentComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var effect = ref _effectAspect.Effect.Get(entity);
                ref var viewDataComponent = ref _effectAspect.ViewData.Get(entity);
                
                if(viewDataComponent.UseEffectRoot) continue;
                
                ref var parentComponent = ref _effectAspect.Parent.Add(entity);
                
                if(!effect.Destination.Unpack(_world, out var destinationEntity) || 
                   !_effectAspect.Avatar.Has(destinationEntity))
                    continue;

                ref var avatarComponent = ref _effectAspect.Avatar.Get(destinationEntity);

                var index = (int)viewDataComponent.ViewInstanceType;
                var count = avatarComponent.All.Length;
                
                parentComponent.Value = count <= 0 || count<=index ? null : avatarComponent.All[index];
            }
        }
    }
}