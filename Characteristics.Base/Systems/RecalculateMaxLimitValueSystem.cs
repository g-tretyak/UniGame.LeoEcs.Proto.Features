namespace UniGame.Ecs.Proto.Characteristics.Base.Systems
{
    using System;
    using Components;
    using Components.Requests;
    using Game.Modules.UnioModules.UniGame.LeoEcsLite.LeoEcs.Shared.Components;
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
    public class RecalculateMaxLimitValueSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _recalculateRequestFilter;
        private EcsFilter _maxLimitFilter;
        
        private ProtoPool<ModificationComponent> _modificationPool;
        private ProtoPool<CharacteristicLinkComponent> _characteristicsValueLinkPool;
        private ProtoPool<MaxLimitModificationsValueComponent> _valuePool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _recalculateRequestFilter = _world
                .Filter<RecalculateCharacteristicSelfRequest>()
                .Inc<CharacteristicValueComponent>()
                .Inc<CharacteristicBaseValueComponent>()
                .Inc<MaxLimitModificationsValueComponent>()
                .Inc<MaxValueComponent>()
                .End();
            
            _maxLimitFilter = _world
                .Filter<ModificationComponent>()
                .Inc<ModificationMaxLimitComponent>()
                .Inc<CharacteristicLinkComponent>()
                .End();
    
            _modificationPool = _world.GetPool<ModificationComponent>();
            _characteristicsValueLinkPool = _world.GetPool<CharacteristicLinkComponent>();
            _valuePool = _world.GetPool<MaxLimitModificationsValueComponent>();
        }

        public void Run()
        {
            foreach (var characteristicEntity in _recalculateRequestFilter)
            {
                ref var maxLimitValueComponent = ref _valuePool.Get(characteristicEntity);

                var maxValue = 0f;

                foreach (var modificationEntity in _maxLimitFilter)
                {
                    ref var linkComponent = ref _characteristicsValueLinkPool.Get(modificationEntity);
                    if(!linkComponent.Link.Unpack(_world,out var characteristicValue))
                        continue;
                    if(!characteristicEntity.Equals(characteristicValue)) continue;
                    
                    ref var modificationComponent = ref _modificationPool.Get(modificationEntity);
                    maxValue += modificationComponent.Counter * modificationComponent.BaseValue;
                }
                
                maxLimitValueComponent.Value = maxValue;
            }
        }
    }
}