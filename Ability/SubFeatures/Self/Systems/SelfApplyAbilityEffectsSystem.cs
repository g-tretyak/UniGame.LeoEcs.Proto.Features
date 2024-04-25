namespace unigame.ecs.proto.Ability.SubFeatures.Self.Systems
{
    using Common.Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
	

    /// <summary>
    /// Apply ability effects to self.
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public sealed class SelfApplyAbilityEffectsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<SelfEffectsComponent> _effectsPool;
        private ProtoPool<OwnerComponent> _ownerPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<SelfEffectsComponent>()
                .Inc<ApplyAbilityEffectsSelfRequest>()
                .Inc<OwnerComponent>()
                .End();
            
            _effectsPool = _world.GetPool<SelfEffectsComponent>();
            _ownerPool = _world.GetPool<OwnerComponent>();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var owner = ref _ownerPool.Get(entity);
                ref var effects = ref _effectsPool.Get(entity);
                
                effects.Effects.CreateRequests(_world, owner.Value, owner.Value);
            }
        }
    }
}