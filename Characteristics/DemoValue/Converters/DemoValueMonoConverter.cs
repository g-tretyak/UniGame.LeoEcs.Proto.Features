namespace unigame.ecs.proto.Characteristics.DemoValue.Converters
{
    using System;
    using System.Collections.Generic;
    using Base.Modification;
    using Components;
    using unigame.ecs.proto.Characteristics.Base.Components;
    using unigame.ecs.proto.Characteristics.Base.Components.Requests;
    using unigame.ecs.proto.Characteristics.Base.Components.Requests.OwnerRequests;
     
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime.Converters;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UnityEngine.Serialization;

    public class DemoValueMonoConverter : MonoLeoEcsConverter<DemoValueComponentConverter>
    {
        [TitleGroup("DEBUG ViEW COMPONENT")]
        [InlineProperty]
        [HideLabel]
        public CharacteristicComponent<DemoValueComponent> characteristicComponent = new CharacteristicComponent<DemoValueComponent>();

        [FormerlySerializedAs("addValue")]
        [TitleGroup("COMMANDS")]
        [InlineButton(nameof(Add))]
        public float value = 10;
        
        [FormerlySerializedAs("setMaxLimit")]
        [TitleGroup("COMMANDS")]
        [InlineButton(nameof(SetMaxLimit))]
        public float maxLimit = 10;
        
        [FormerlySerializedAs("setMinLimit")]
        [TitleGroup("COMMANDS")]
        [InlineButton(nameof(SetMinLimit))]
        public float minLimit = 10;
        
        [FormerlySerializedAs("setBaseValue")]
        [TitleGroup("COMMANDS")]
        [InlineButton(nameof(AddBaseValue))]
        public float baseValue = 10;

        [TitleGroup("MODIFICATIONS")]
        [InlineButton(nameof(AddModification))]
        [HideLabel]
        [InlineProperty]
        public DemoModificationValue modification;
        
        [TitleGroup("MODIFICATIONS")] 
        //[InlineProperty]
        public List<DemoModificationValue> modifications = new List<DemoModificationValue>();

        private int _entity;
        private ProtoPackedEntity _packedEntity;
        private ProtoWorld _world;
        private List<DemoModificationValue> _removedItems = new List<DemoModificationValue>();

        public bool IsActive => _world != null && _world.IsAlive();
        
        protected override void OnApply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            _entity = entity;
            _world = world;
            _packedEntity = world.PackEntity(entity);
            
            ref var baseHealthComponent = ref world.AddComponent<DemoValueComponent>(entity);
            baseHealthComponent.Value = value;
            
            ref var valueComponent = ref world
                .AddComponent<CreateCharacteristicRequest<DemoValueComponent>>(entity);
            
            valueComponent.Value = baseValue;
            valueComponent.MinValue = minLimit;
            valueComponent.MaxValue = maxLimit;
            valueComponent.Owner = world.PackEntity(entity);
        }

        public void AddModification()
        {
            var modificationValue = modification.Create(_world, _entity);
            modifications.Add(modificationValue);
            modificationValue.Apply();
        }

        public void Add()
        {
            if (!IsActive) return;
            var targetEntity = _world.NewEntity();
            ref var requestComponent = ref _world.AddComponent<ChangeCharacteristicValueRequest<DemoValueComponent>>(targetEntity);
            requestComponent.Source = _packedEntity;
            requestComponent.Value = value;
            requestComponent.Target = _world.PackEntity(_entity);
        }

        public void SetMaxLimit()
        {
            if (!IsActive) return;
            ref var requestComponent = ref _world.GetOrAddComponent<ChangeMaxLimitSelfRequest<DemoValueComponent>>(_entity);
            requestComponent.Value = maxLimit;
        }
        
        public void SetMinLimit()
        {
            if (!IsActive) return;
            ref var requestComponent = ref _world.GetOrAddComponent<ChangeMinLimitSelfRequest<DemoValueComponent>>(_entity);
            requestComponent.Value = minLimit;
        }
        
        public void AddBaseValue()
        {
            if (!IsActive) return;
            var targetEntity = _world.NewEntity();
            ref var requestComponent = ref _world.AddComponent<ChangeCharacteristicBaseRequest<DemoValueComponent>>(targetEntity);
            requestComponent.Source = _packedEntity;
            requestComponent.Value = value;
            requestComponent.Target = _world.PackEntity(_entity);
        }
        
        [EnableIf(nameof(IsActive))]
        [TitleGroup("COMMANDS")]
        [Button]
        public void Reset()
        {
            ref var requestComponent = ref _world.GetOrAddComponent<ResetCharacteristicSelfRequest<DemoValueComponent>>(_entity);
        }
        
        [EnableIf(nameof(IsActive))]
        [TitleGroup("COMMANDS")]
        [Button]
        public void Recalculate()
        {
            ref var requestComponent = ref _world
                .GetOrAddComponent<RecalculateCharacteristicSelfRequest<DemoValueComponent>>(_entity);
        }
        
        private ProtoPool<CharacteristicComponent<DemoValueComponent>> _characteristicPool;

        private void Update()
        {
            if (!IsActive) return;

            foreach (var demoModificationValue in modifications)
            {
                if(!demoModificationValue.SourceEntity.Unpack(_world,out var sourceEntity))
                    _removedItems.Add(demoModificationValue);
            }

            foreach (var removedItem in _removedItems)
                modifications.Remove(removedItem);

            _characteristicPool ??= _world.GetPool<CharacteristicComponent<DemoValueComponent>>();
            
            if(!_packedEntity.Unpack(_world,out var entity)) return;
            if(!_characteristicPool.Has(entity)) return;

            ref var component = ref _characteristicPool.Get(entity);

            characteristicComponent = component;
        }
        
    }

    [Serializable]
    public class DemoModificationValue
    {
        public ProtoPackedEntity SourceEntity;
        public ProtoPackedEntity Entity;
        public Modification Modification;
        
        private ProtoWorld _world;
        
        public bool IsAlive => _world != null && _world.IsAlive();
        
        [EnableIf(nameof(IsAlive))]
        [Button]
        public void Kill()
        {
            if(SourceEntity.Unpack(_world,out var sourceEntity))
                _world.DelEntity(sourceEntity);
        }
        
        [EnableIf(nameof(IsAlive))]
        [Button]
        public void Remove()
        {
            var requestEntity = _world.NewEntity();
            ref var requestComponent = ref _world.AddComponent<RemoveCharacteristicModificationRequest<DemoValueComponent>>(requestEntity);
            requestComponent.Target = Entity;
            requestComponent.Source = SourceEntity;
        }

        [EnableIf(nameof(IsAlive))]
        [Button]
        public void Apply()
        {
            var requestEntity = _world.NewEntity();
            ref var requestComponent = ref _world.AddComponent<AddModificationRequest<DemoValueComponent>>(requestEntity);
            requestComponent.Modification = Modification;
            requestComponent.Target = Entity;
            requestComponent.ModificationSource = SourceEntity;
        }
        
        public DemoModificationValue Create(ProtoWorld world,int entity)
        {
            var modification = new Modification()
            {
                baseValue = Modification.baseValue, 
                isPercent = Modification.isPercent,
                allowedSummation = Modification.allowedSummation, 
                isMaxLimitModification = Modification.isMaxLimitModification,
                counter = Modification.counter
            };
            
            var sourceEntity = world.NewEntity();
            world.AddComponent<ModificationSourceComponent>(sourceEntity);
            
            var value = new DemoModificationValue()
            {
                _world = world,
                SourceEntity = world.PackEntity(sourceEntity),
                Entity = world.PackEntity(entity),
                Modification = modification,
            };

            return value;
        }
    }
}