namespace UniGame.Ecs.Proto.GameEffects.JumpForwardEffect.Systems
{
    using Component;
    using Effects.Components;
     
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// Create request for jump forward effect
    /// </summary>

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public sealed class CreateJumpForwardEffectSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private ProtoPool<JumpForwardEffectRequest> _jumpForwardRequestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<EffectComponent>()
                .Inc<ApplyEffectSelfRequest>()
                .Inc<JumpForwardEffectComponent>()
                .End();
            _jumpForwardRequestPool = _world.GetPool<JumpForwardEffectRequest>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var request = ref _jumpForwardRequestPool.Add(_world.NewEntity());
                request.Source = _world.PackEntity(entity);
            }
        }
    }
}