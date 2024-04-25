namespace unigame.ecs.proto.Characteristics.Base.Systems
{
    using System;
    using Components;
    using Components.Events;
    using Game.Ecs.Core.Components;
    using unigame.ecs.proto.Core.Components;
    using Game.Modules.UnioModules.UniGame.LeoEcsLite.LeoEcs.Shared.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;


    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class DetectCharacteristicChangesSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _changeRequestFilter;
        
        private ProtoPool<CharacteristicChangedComponent> _changedPool;
        private ProtoPool<OwnerComponent> _ownerPool;
        private ProtoPool<CharacteristicPreviousValueComponent> _previousPool;
        
        private ProtoPool<CharacteristicValueChangedEvent> _eventPool;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _changeRequestFilter = _world
                .Filter<CharacteristicChangedComponent>()
                .Inc<CharacteristicValueComponent>()
                .Inc<MinValueComponent>()
                .Inc<MaxValueComponent>()
                .Inc<CharacteristicBaseValueComponent>()
                .End();
            
            _changedPool = _world.GetPool<CharacteristicChangedComponent>();
            _eventPool = _world.GetPool<CharacteristicValueChangedEvent>();
            _ownerPool = _world.GetPool<OwnerComponent>();
            _previousPool = _world.GetPool<CharacteristicPreviousValueComponent>();
        }

        public void Run()
        {
            foreach (var changesEntity in _changeRequestFilter)
            {
                ref var changedComponent = ref _changedPool.Get(changesEntity);
                ref var previousValue = ref _previousPool.Get(changesEntity);
                ref var ownerComponent = ref _ownerPool.Get(changesEntity);
                
                var eventEntity = _world.NewEntity();
                ref var eventComponent = ref _eventPool.Add(eventEntity);
                eventComponent.Owner = ownerComponent.Value;
                eventComponent.Value = changedComponent.Value;
                eventComponent.PreviousValue = previousValue.Value;
                eventComponent.Characteristic = _world.PackEntity(changesEntity);
            }
        }
    }
}