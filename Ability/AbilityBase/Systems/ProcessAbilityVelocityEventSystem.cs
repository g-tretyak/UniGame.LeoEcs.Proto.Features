namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    using System;
    using Components;
    using Game.Ecs.Core.Death.Components;
    using Game.Ecs.Input.Components.Evetns;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ProcessAbilityVelocityEventSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<AbilityCellVelocityEvent> _velocityEventPool;
        private ProtoPool<AbilityMapComponent> _abilityMapPool;
        private ProtoPool<AbilityVelocityEvent> _abilityVelocityPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<AbilityCellVelocityEvent>()
                .Inc<AbilityMapComponent>()
                .Exc<DestroyComponent>()
                .End();
            
            _velocityEventPool = _world.GetPool<AbilityCellVelocityEvent>();
            _abilityMapPool = _world.GetPool<AbilityMapComponent>();
            _abilityVelocityPool = _world.GetPool<AbilityVelocityEvent>();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var velocity = ref _velocityEventPool.Get(entity);
                ref var map = ref _abilityMapPool.Get(entity);
                
                if(!map.Abilities[velocity.Id].Unpack(_world, out var abilityEntity))
                    continue;

                ref var abilityVelocity = ref _abilityVelocityPool.GetOrAddComponent(abilityEntity);
                abilityVelocity.Value = velocity.Value;
            }
        }
    }
}