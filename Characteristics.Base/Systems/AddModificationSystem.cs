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
    /// add new modification to characteristic
    /// if modification already exist - update it
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class AddModificationSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private CharacteristicsAspect _characteristicsAspect;
        private ModificationsAspect _modificationsAspect;
        
        private ProtoIt _addModificationFilter = It
            .Chain<AddModificationRequest>()
            .End();
        
        private ProtoIt _modificationsFilter= It
            .Chain<ModificationComponent>()
            .Inc<CharacteristicLinkComponent>()
            .End();


        public void Run()
        {
            foreach (var requestEntity in _addModificationFilter)
            {
                ref var requestComponent = ref _modificationsAspect.AddModification.Get(requestEntity);
                if (!requestComponent.Target.Unpack(_world, out var targetCharacteristicEntity))
                    continue;

                if (!requestComponent.Source.Unpack(_world, out var targetSourceEntity))
                    targetSourceEntity = (ProtoEntity)(-1);

                //check is target is characteristic entity
                if(!_characteristicsAspect.Value.Has(targetCharacteristicEntity)) continue;
                
                var foundedCharacteristicEntity = (ProtoEntity)(-1);

                foreach (var modificationEntity in _modificationsFilter)
                {
                    ref var linkComponent = ref _modificationsAspect.CharacteristicLink.Get(modificationEntity);
                    if (!linkComponent.Link.Unpack(_world, out var characteristicEntity)) continue;
                    
                    if (!characteristicEntity.Equals(targetCharacteristicEntity)) continue;

                    ref var sourceComponent = ref _modificationsAspect.SourceLink.Get(modificationEntity);
                    if (!sourceComponent.Value.Unpack(_world, out var sourceEntity)) continue;
                    
                    if(!sourceEntity.Equals(targetSourceEntity)) continue;
                    
                    foundedCharacteristicEntity = characteristicEntity;

                    ref var modificationComponent = ref _modificationsAspect.Modification.Get(modificationEntity);
                    
                    if (!modificationComponent.AllowedSummation) break;

                    modificationComponent.Counter++;

                    _characteristicsAspect.Recalculate
                        .GetOrAddComponent(foundedCharacteristicEntity);
                    
                    break;
                }
                
                if ((int)foundedCharacteristicEntity > 0) continue;

                var createEntity = _world.NewEntity();
                ref var createComponent = ref _modificationsAspect.CreateModification.Add(createEntity);
                createComponent.Target = requestComponent.Target;
                createComponent.Source = requestComponent.Source;
                createComponent.Modification = requestComponent.Modification;
            }
        }
    }
}