namespace UniGame.Ecs.Proto.Presets.Systems
{
    using System;
    using Components;
    using Game.Ecs.Time.Service;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Apply material preset to target system.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class FindPresetTargetsSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _targetFilter;
        private EcsFilter _sourceFilter;
        
        private ProtoPool<PresetIdComponent> _idPool;
        private ProtoPool<PresetApplyingDataComponent> _applyingDataPool;
        private ProtoPool<PresetApplyingComponent> _applyingPool;
        private ProtoPool<PresetDurationComponent> _durationPool;
        private ProtoPool<PresetActivatedComponent> _activatedPresetPool;
        private ProtoPool<PresetProgressComponent> _progressPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _targetFilter = _world
                .Filter<PresetIdComponent>()
                .Inc<PresetTargetComponent>()
                .Exc<PresetApplyingComponent>()
                .Exc<PresetApplyingDataComponent>()
                .End();
            
            _sourceFilter = _world
                .Filter<PresetIdComponent>()
                .Inc<PresetSourceComponent>()
                .Inc<ActivePresetSourceComponent>()
                .End();

            _idPool = _world.GetPool<PresetIdComponent>();
            _applyingDataPool = _world.GetPool<PresetApplyingDataComponent>();
            _applyingPool = _world.GetPool<PresetApplyingComponent>();
            _durationPool = _world.GetPool<PresetDurationComponent>();
            _activatedPresetPool = _world.GetPool<PresetActivatedComponent>();
            _progressPool = _world.GetPool<PresetProgressComponent>();
        }

        public void Run()
        {
            foreach (var targetEntity in _targetFilter)
            {
                ref var targetIdComponent = ref _idPool.Get(targetEntity);
                
                foreach (var sourceEntity in _sourceFilter)
                {
                    ref var sourceIdComponent = ref _idPool.Get(sourceEntity);
                    if(sourceIdComponent.Value != targetIdComponent.Value) continue;

                    ref var progressComponent = ref _progressPool.GetOrAddComponent(targetEntity);
                    ref var applyingDataComponent = ref _applyingDataPool.Add(targetEntity);
                    ref var applyingComponent = ref _applyingPool.Add(targetEntity);

                    progressComponent.Value = 0f;
                    applyingDataComponent.Duration = 0;
                    applyingDataComponent.StartTime = GameTime.Time;
                    
                    if (_durationPool.Has(sourceEntity))
                    {
                        ref var durationComponent = ref _durationPool.Get(sourceEntity);
                        applyingDataComponent.Duration = durationComponent.Value;
                    }

                    applyingDataComponent.Source = sourceEntity.PackEntity(_world);

                    _activatedPresetPool.GetOrAddComponent(sourceEntity);
                    
                    break;
                }
            }
        }
    }
}