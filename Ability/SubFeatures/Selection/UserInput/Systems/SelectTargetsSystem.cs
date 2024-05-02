namespace UniGame.Ecs.Proto.Ability.SubFeatures.Selection.UserInput.Systems
{
    using System;
    using Characteristics.Radius.Component;
    using Common.Components;
    using Components;
    using Game.Code.GameLayers.Relationship;
    using Game.Ecs.Core.Components;
    using GameLayers.Category.Components;
    using GameLayers.Layer.Components;
    using GameLayers.Relationship.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Proto.Selection;
    using TargetSelection;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class SelectTargetsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private readonly float _radiusMultiplier;
        private EcsFilter _filter;
        private ProtoWorld _world;

        private TargetSelectionSystem _selectionSystem;
        private ProtoEntity[] _selection = new ProtoEntity[TargetSelectionData.MaxTargets];
        private ProtoPackedEntity[] _packedEntities = new ProtoPackedEntity[TargetSelectionData.MaxTargets];
        
        private ProtoPool<SelectedTargetsComponent> _targetsPool;
        private ProtoPool<RadiusComponent> _radiusPool;
        private ProtoPool<RelationshipIdComponent> _relationshipPool;
        private ProtoPool<CategoryIdComponent> _categoryPool;
        private ProtoPool<OwnerComponent> _ownerPool;
        private ProtoPool<TransformComponent> _transformPool;
        private ProtoPool<TransformPositionComponent> _positionPool;
        private ProtoPool<LayerIdComponent> _layerPool;
        private ProtoPool<PrepareToDeathComponent> _prepareToDeath;

        public SelectTargetsSystem(float radiusMultiplier = 1.5f) // TODO: to global config?
        {
            _radiusMultiplier = radiusMultiplier;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _selectionSystem = _world.GetGlobal<TargetSelectionSystem>();
            
            _filter = _world
                .Filter<AbilityInHandComponent>()
                .Inc<SelectableAbilityComponent>()
                .Inc<RelationshipIdComponent>()
                .Inc<CategoryIdComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var owner = ref _ownerPool.Get(entity);
                if (!owner.Value.Unpack(_world, out var ownerEntity))
                    continue;

                ref var targets = ref _targetsPool.GetOrAddComponent(entity);

                if (_prepareToDeath.Has(ownerEntity))
                {
                    targets.SetEntities(Array.Empty<ProtoPackedEntity>(),0);
                    continue;
                }

                ref var relationship = ref _relationshipPool.Get(entity);
                if (relationship.Value.IsSelf())
                    targets.SetEntity(owner.Value);

                ref var radius = ref _radiusPool.Get(entity);

                ref var ownerPosition = ref _positionPool.Get(ownerEntity);
                ref var ownerLayerMask = ref _layerPool.Get(ownerEntity);
                
                var areaCenter = ownerPosition.Position;
                var searchRadius = radius.Value * _radiusMultiplier;

                ref var category = ref _categoryPool.Get(entity);
                var layer = relationship.Value.GetFilterMask(ownerLayerMask.Value);
                
                var amount = _selectionSystem.SelectEntitiesInArea(
                    _selection,
                    searchRadius, 
                    ref areaCenter,
                    ref layer, 
                    ref category.Value);

                for (var i = 0; i < amount; i++)
                    _packedEntities[i] = _selection[i].PackEntity(_world);
                
                targets.SetEntities(_packedEntities,amount);
            }
        }
    }
}