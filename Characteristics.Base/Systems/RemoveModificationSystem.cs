namespace UniGame.Ecs.Proto.Characteristics.Base.Systems
{
    using System;
    using Components;
    using Components.Requests;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// remove modification from characteristics and make recalculate request
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class RemoveModificationSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _removeRequestFilter;
        private EcsFilter _modificationsFilter;
        private ProtoPool<ModificationSourceLinkComponent> _sourceLinkPool;
        private ProtoPool<CharacteristicLinkComponent> _characteristicsLinkPool;
        private ProtoPool<RecalculateModificationSelfRequest> _recalculateModificationPool;
        private ProtoPool<ModificationComponent> _modificationPool;
        private ProtoPool<RemoveModificationRequest> _removeRequestPool;
        private ProtoPool<RecalculateCharacteristicSelfRequest> _recalculateCharacteristicPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _removeRequestFilter = _world
                .Filter<RemoveModificationRequest>()
                .End();
            
            _modificationsFilter = _world
                .Filter<ModificationComponent>()
                .Inc<CharacteristicLinkComponent>()
                .Inc<ModificationSourceLinkComponent>()
                .End();

            _removeRequestPool = _world.GetPool<RemoveModificationRequest>();
            _sourceLinkPool = _world.GetPool<ModificationSourceLinkComponent>();
            _modificationPool = _world.GetPool<ModificationComponent>();
            _characteristicsLinkPool = _world.GetPool<CharacteristicLinkComponent>();
            _recalculateCharacteristicPool = _world.GetPool<RecalculateCharacteristicSelfRequest>();
            
        }

        public void Run()
        {
            foreach (var removeRequestEntity in _removeRequestFilter)
            {
                ref var requestComponent = ref _removeRequestPool.Get(removeRequestEntity);
                
                if(!requestComponent.Source.Unpack(_world,out var modificationSourceEntity))
                    continue;
                
                if(!requestComponent.Characteristic.Unpack(_world,out var targetCharacteristic))
                    continue;
                
                foreach (var modificationEntity in _modificationsFilter)
                {
                    ref var modificationSourceLinkComponent = ref _sourceLinkPool.Get(modificationEntity);
                    if (!modificationSourceLinkComponent.Value.Unpack(_world,out var sourceEntity))
                        continue;
                    
                    ref var characteristicsLinkComponent = ref _characteristicsLinkPool.Get(modificationEntity);
                    if (!characteristicsLinkComponent.Link.Unpack(_world, out var characteristicEntity))
                        continue;
                    
                    if(!sourceEntity.Equals(modificationSourceEntity)) continue;
                    if(!targetCharacteristic.Equals(characteristicEntity)) continue;
                    
                    ref var modificationComponent = ref _modificationPool.Get(modificationEntity);
                    modificationComponent.Counter -= 1;
                    
                    if (modificationComponent.Counter <= 0)
                        _world.DelEntity(modificationEntity);

                    _recalculateCharacteristicPool.GetOrAddComponent(characteristicEntity);
                }
            }
        }
    }
}