namespace unigame.ecs.proto.Characteristics.Base.Systems
{
    using System;
    using Components;
    using Components.Requests;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;


    /// <summary>
    /// recalculate characteristic by modifications
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class RecalculateModificationsValueSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _recalculateRequestFilter;
        private EcsFilter _modificationsFilter;
        
        private ProtoPool<ModificationComponent> _modificationPool;
        private ProtoPool<CharacteristicLinkComponent> _characteristicsValueLinkPool;
        
        private ProtoPool<CharacteristicBaseValueComponent> _baseValuePool;
        private ProtoPool<BaseModificationsValueComponent> _valueModificationsPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _recalculateRequestFilter = _world
                .Filter<RecalculateCharacteristicSelfRequest>()
                .Inc<CharacteristicValueComponent>()
                .Inc<CharacteristicBaseValueComponent>()
                .End();
  
            _modificationsFilter = _world
                .Filter<ModificationComponent>()
                .Inc<CharacteristicLinkComponent>()
                .Exc<ModificationPercentComponent>()
                .Exc<ModificationMaxLimitComponent>()
                .End();
            
            _baseValuePool = _world.GetPool<CharacteristicBaseValueComponent>();
            _modificationPool = _world.GetPool<ModificationComponent>();
            _characteristicsValueLinkPool = _world.GetPool<CharacteristicLinkComponent>();
            _valueModificationsPool = _world.GetPool<BaseModificationsValueComponent>();
        }

        public void Run()
        {
            foreach (var characteristicEntity in _recalculateRequestFilter)
            {
                ref var baseValueComponent = ref _baseValuePool.Get(characteristicEntity);
                ref var valueModificationsComponent = ref _valueModificationsPool.Get(characteristicEntity);

                var newValue = baseValueComponent.Value;
                
                foreach (var modificationEntity in _modificationsFilter)
                {
                    ref var linkComponent = ref _characteristicsValueLinkPool.Get(modificationEntity);
                    if(!linkComponent.Link.Unpack(_world,out var characteristicValue))
                        continue;
                    if(!characteristicEntity.Equals(characteristicValue)) continue;

                    ref var modificationComponent = ref _modificationPool.Get(modificationEntity);
                    newValue += modificationComponent.Counter * modificationComponent.BaseValue;
                }

                valueModificationsComponent.Value = newValue;
            }
        }
    }
}