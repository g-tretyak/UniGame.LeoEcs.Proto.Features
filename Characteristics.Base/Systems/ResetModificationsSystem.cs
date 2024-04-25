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
    /// reset all modifications from characteristic
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ResetModificationsSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _requestFilter;
        private EcsFilter _modificationsFilter;
        
        private ProtoPool<ResetModificationsRequest> _resetPool;
        private ProtoPool<CharacteristicValueComponent> _characteristicPool;
        
        private ProtoPool<CharacteristicLinkComponent> _linkPool;
        private ProtoPool<RecalculateCharacteristicSelfRequest> _recalculatePool;
        private ProtoPool<CharacteristicDefaultValueComponent> _defaultPool;
        private ProtoPool<CharacteristicBaseValueComponent> _baseValuePool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _requestFilter = _world
                .Filter<ResetModificationsRequest>()
                .End();

            _modificationsFilter = _world
                .Filter<ModificationComponent>()
                .Inc<CharacteristicLinkComponent>()
                .End();

            _resetPool = _world.GetPool<ResetModificationsRequest>();
            _characteristicPool = _world.GetPool<CharacteristicValueComponent>();
            _linkPool = _world.GetPool<CharacteristicLinkComponent>();
            _recalculatePool = _world.GetPool<RecalculateCharacteristicSelfRequest>();
            _defaultPool = _world.GetPool<CharacteristicDefaultValueComponent>();
            _baseValuePool = _world.GetPool<CharacteristicBaseValueComponent>();
        }

        public void Run()
        {
            foreach (var requestEntity in _requestFilter)
            {
                ref var resetComponent = ref _resetPool.Get(requestEntity);
                ref var characteristic = ref resetComponent.Characteristic;
                _resetPool.Del(requestEntity);
                
                if(!characteristic.Unpack(_world,out var characteristicEntity))
                    continue;
                
                if(!_characteristicPool.Has(characteristicEntity)) continue;

                var isModificationChanged = false;
                
                //remove all modifications
                foreach (var modificationEntity in _modificationsFilter)
                {
                    ref var characteristicLinkComponent = ref _linkPool.Get(modificationEntity);
                    if(!characteristicLinkComponent.Link.Unpack(_world,out var characteristicLinkEntity))
                        continue;
                    if(!characteristicLinkEntity.Equals(characteristicEntity)) continue;
                    
                    isModificationChanged = true;
                    
                    _world.DelEntity(modificationEntity);
                }

                if (!isModificationChanged) return;

                _recalculatePool.GetOrAddComponent(characteristicEntity);
            }
        }
    }
}