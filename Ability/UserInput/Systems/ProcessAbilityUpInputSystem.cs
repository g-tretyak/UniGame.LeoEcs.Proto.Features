namespace UniGame.Ecs.Proto.Ability.UserInput.Systems
{
    using Common.Components;
    using Components;
    using Game.Ecs.Core.Death.Components;
    using Game.Ecs.Input.Components;
    using Game.Ecs.Input.Components.Requests;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public sealed class ProcessAbilityUpInputSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<SetInHandAbilityBySlotSelfRequest> _inHandRequestPool;
        private ProtoPool<AbilityUpInputRequest> _upPool;
        private ProtoPool<AbilityMapComponent> _abilityMapPool;
        private ProtoPool<CanApplyWhenUpInputComponent> _canUpPool;
        private ProtoPool<ApplyAbilityBySlotSelfRequest> _applyRequestPool;
        private ProtoPool<AbilityActiveTimeComponent> _activateTimePool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<AbilityUpInputRequest>()
                .Inc<UserInputTargetComponent>()
                .Inc<AbilityMapComponent>()
                .Exc<DisabledComponent>()
                .End();
            
            _inHandRequestPool = _world.GetPool<SetInHandAbilityBySlotSelfRequest>();
            _upPool = _world.GetPool<AbilityUpInputRequest>();
            _abilityMapPool = _world.GetPool<AbilityMapComponent>();
            _canUpPool = _world.GetPool<CanApplyWhenUpInputComponent>();
            _applyRequestPool = _world.GetPool<ApplyAbilityBySlotSelfRequest>();
            _activateTimePool = _world.GetPool<AbilityActiveTimeComponent>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var up = ref _upPool.Get(entity);
                ref var abilityMap = ref _abilityMapPool.Get(entity);

                if (!abilityMap.AbilityEntities[up.Id].Unpack(_world, out var abilityEntity))
                    continue;

                if (!_canUpPool.Has(abilityEntity))
                    continue;

                if (_applyRequestPool.Has(entity))
                    continue;
                
                if (!_inHandRequestPool.Has(entity))
                {
                    ref var inHand = ref _inHandRequestPool.Add(entity);
                    inHand.AbilityCellId = up.Id;
                }
                
                ref var activateTime = ref _activateTimePool.GetOrAddComponent(abilityEntity);
                activateTime.Time = up.ActiveTime;

                ref var request = ref _applyRequestPool.Add(entity);
                request.AbilitySlot = up.Id;
            }
        }
    }
}