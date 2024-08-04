namespace UniGame.Ecs.Proto.GameAi.ActivateAbility
{
    using System;
    using Ability.Aspects;
    using Ability.Tools;
    using AI.Components;
    using Components;
    using Game.Code.Ai.ActivateAbility;
    using Game.Code.Ai.ActivateAbility.Aspects;
    using Game.Code.GameLayers.Relationship;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Selection;
    using TargetSelection;
    using UniGame.Core.Runtime;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.Collections;
    using Unity.Mathematics;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SelectAbilityTargetsDataPlannerSystem : IProtoRunSystem , IProtoInitSystem
    {
        private AbilityAspect _abilityTools;
        private TargetSelectionSystem _targetSelection;
        private AbilityAiActionAspect _aiActionAspect;
        private AbilityOwnerAspect _abilityOwnerAspect;
        private NativeHashSet<int> _entitySet;

        private ProtoWorld _world;
        private ILifeTime _lifeTime;

        private ProtoPackedEntity[] _selection = new ProtoPackedEntity[TargetSelectionData.MaxTargets];

        private ProtoItExc _filter= It
            .Chain<AiAgentComponent>()
            .Inc<AbilityByRangeComponent>()
            .Inc<ActivateAbilityPlannerComponent>()
            .Exc<AbilityAiActionTargetComponent>()
            .Exc<PrepareToDeathComponent>()
            .End();
        
        public void Init(IProtoSystems systems)
        {
            _entitySet = new NativeHashSet<int>(10, Allocator.Persistent)
                .AddTo(_lifeTime);
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                var abilityInUse = _abilityTools.GetNonDefaultAbilityInUse(entity);
                if(abilityInUse.Unpack(_world,out var ability)) continue;
                
                _entitySet.Clear();
                
                ref var rangeComponent = ref _aiActionAspect.ByRangeAbility.Get(entity);
                ref var gameLayerComponent = ref _aiActionAspect.LayerId.Get(entity);
                ref var entityTransformComponent = ref _aiActionAspect.Transform.Get(entity);
                ref var radiusComponent = ref _aiActionAspect.ByRangeAbility.Get(entity);

                var filters = rangeComponent.FilterData;
                
                foreach (var filter in filters)
                {
                    var abilitySlot = filter.Slot;
                    if(_entitySet.Contains(abilitySlot)) continue;

                    _entitySet.Add(abilitySlot);
                    
                    var abilityEntity = _abilityTools.GetAbilityBySlot(entity, abilitySlot);
                    if(!abilityEntity.Unpack(_world,out var targetAbility)) continue;
                    
                    ref var dataComponent = ref _aiActionAspect
                        .AbilityRangeData
                        .GetOrAddComponent(targetAbility);

                    ref var filterComponent = ref _aiActionAspect.Relationship.Get(targetAbility);
                    ref var categoryIdComponent = ref _aiActionAspect.Category.Get(targetAbility);

                    var entityPosition = (float3)entityTransformComponent.Value.position;

                    //create relation mask by gamelayer id
                    var gameLayerMask = filterComponent.Value.GetFilterMask(gameLayerComponent.Value);

                    var amount = _targetSelection.SelectEntitiesInArea(
                        _selection,
                        radiusComponent.Radius,
                        ref entityPosition,
                        ref gameLayerMask,
                        ref categoryIdComponent.Value);

                    dataComponent.Count = amount;
                    
                    for (var i = 0; i < amount; i++)
                        dataComponent.Values[i] = _selection[i];
                }
            }
        }
    }
}