namespace UniGame.Ecs.Proto.Characteristics.Base.Systems
{
    using System;
    using Aspects;
    using Components;
    using Components.Requests;
    using LeoEcs.Bootstrap.Runtime.Attributes;
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
    [ECSDI]
    public class ResetModificationsSystem : IProtoRunSystem
    {
        private ProtoWorld _world;

        private ProtoIt _requestFilter = It
            .Chain<ResetModificationsRequest>()
            .End();

        private ProtoIt _modificationsFilter = It
            .Chain<ModificationComponent>()
            .Inc<CharacteristicLinkComponent>()
            .End();

        private ModificationsAspect _modificationsAspect;
        private CharacteristicsAspect _characteristicsAspect;

        public void Run()
        {
            foreach (var requestEntity in _requestFilter)
            {
                ref var resetComponent = ref _modificationsAspect
                    .ResetModifications.Get(requestEntity);
                
                ref var characteristic = ref resetComponent.Characteristic;

                _modificationsAspect.ResetModifications.Del(requestEntity);

                if (!characteristic.Unpack(_world, out var characteristicEntity))
                    continue;

                if (!_characteristicsAspect.Value.Has(characteristicEntity)) continue;

                var isModificationChanged = false;

                //remove all modifications
                foreach (var modificationEntity in _modificationsFilter)
                {
                    ref var characteristicLinkComponent = ref _characteristicsAspect
                        .CharacteristicLink
                        .Get(modificationEntity);
                    
                    if (!characteristicLinkComponent.Link.Unpack(_world, out var characteristicLinkEntity))
                        continue;
                    
                    if (!characteristicLinkEntity.Equals(characteristicEntity)) continue;

                    isModificationChanged = true;

                    _world.DelEntity(modificationEntity);
                }

                if (!isModificationChanged) return;

                _characteristicsAspect.Recalculate.GetOrAddComponent(characteristicEntity);
            }
        }
    }
}