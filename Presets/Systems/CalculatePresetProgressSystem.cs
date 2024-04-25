namespace unigame.ecs.proto.Presets.Systems
{
    using System;
    using Components;
    using Game.Ecs.Time.Service;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// update preset progression
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class CalculatePresetProgressSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _targetFilter;
        private ProtoPool<PresetApplyingDataComponent> _applyingDataPool;
        private ProtoPool<PresetApplyingComponent> _applyingPool;
        private ProtoPool<PresetProgressComponent> _progressPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _targetFilter = _world
                .Filter<PresetApplyingComponent>()
                .Inc<PresetApplyingDataComponent>()
                .Inc<PresetProgressComponent>()
                .End();
            
            _applyingDataPool = _world.GetPool<PresetApplyingDataComponent>();
            _applyingPool = _world.GetPool<PresetApplyingComponent>();
            _progressPool = _world.GetPool<PresetProgressComponent>();
        }

        public void Run()
        {
            foreach (var targetEntity in _targetFilter)
            {
                ref var dataComponent = ref _applyingDataPool.Get(targetEntity);

                var timePassed = GameTime.Time - dataComponent.StartTime;
                var duration = dataComponent.Duration;
                var progress = duration <= 0 ? 1f : timePassed / duration;
                
                ref var progressComponent = ref _progressPool.Get(targetEntity);
                progressComponent.Value = progress;
            }
        }
    }
}