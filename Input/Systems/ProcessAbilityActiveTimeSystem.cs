namespace unigame.ecs.proto.Input.Systems
{
    using Components.Ability;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public sealed class ProcessAbilityActiveTimeSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<AbilityUpInputRequest>().End();
        }
        
        public void Run()
        {
            var abilityInputRequestPool = _world.GetPool<AbilityUpInputRequest>();
            var abilityInputStatePool = _world.GetPool<AbilityInputState>();

            foreach (var entity in _filter)
            {
                ref var abilityInputState = ref abilityInputStatePool.GetOrAddComponent(entity);

                abilityInputState.ActiveTime += Time.deltaTime;

                ref var abilityInputEvent = ref abilityInputRequestPool.Get(entity);
                abilityInputEvent.ActiveTime = abilityInputState.ActiveTime;
            }
        }
    }
}