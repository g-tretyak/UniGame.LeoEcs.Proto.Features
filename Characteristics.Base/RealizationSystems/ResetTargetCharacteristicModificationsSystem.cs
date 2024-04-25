namespace unigame.ecs.proto.Characteristics.Base.RealizationSystems
{
    using System;
    using Components;
    using Components.Requests;
    using Components.Requests.OwnerRequests;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    /// reset target characteristic value to default
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ResetTargetCharacteristicModificationsSystem<TCharacteristic> : IProtoInitSystem, IProtoRunSystem
        where TCharacteristic : struct
    {
        private ProtoWorld _world;
        private EcsFilter _requestFiler;
        
        private ProtoPool<ResetModificationsRequest> _resetPool;
        private ProtoPool<CharacteristicLinkComponent<TCharacteristic>> _linkPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _requestFiler = _world
                .Filter<ResetCharacteristicModificationsSelfRequest<TCharacteristic>>()
                .End();

            _linkPool = _world.GetPool<CharacteristicLinkComponent<TCharacteristic>>();
            _resetPool = _world.GetPool<ResetModificationsRequest>();
        }

        public void Run()
        {
            foreach (var requestEntity in _requestFiler)
            {
                if(!_linkPool.Has(requestEntity))
                    continue;
                
                ref var linkComponent = ref _linkPool.Get(requestEntity);
                
                var entity = _world.NewEntity();
                ref var resetComponent = ref _resetPool.Add(entity);
                resetComponent.Characteristic = linkComponent.Value;
            }
        }
    }
}