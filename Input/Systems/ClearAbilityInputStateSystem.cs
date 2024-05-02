namespace UniGame.Ecs.Proto.Input.Systems
{
    using Components.Ability;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public sealed class ClearAbilityInputStateSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<AbilityInputState>()
                .Exc<AbilityUpInputRequest>()
                .End();
        }
        
        public void Run()
        {
            var abilityInputStatePool = _world.GetPool<AbilityInputState>();

            foreach (var entity in _filter)
            {
                abilityInputStatePool.Del(entity);
            }
        }
    }
}