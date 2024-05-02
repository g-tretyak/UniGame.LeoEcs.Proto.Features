namespace UniGame.Ecs.Proto.Presets.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
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
    [ECSDI]
    public class ApplyMaterialPresetToTargetSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _targetFilter;

        private ProtoPool<PresetApplyingDataComponent> _applyingDataPool;
        private ProtoPool<MaterialPresetComponent> _materialDataPool;
        private ProtoPool<PresetProgressComponent> _progressPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _targetFilter = _world
                .Filter<MaterialPresetComponent>()
                .Inc<PresetTargetComponent>()
                .Inc<PresetApplyingComponent>()
                .Inc<PresetProgressComponent>()
                .Inc<PresetApplyingDataComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var targetEntity in _targetFilter)
            {
                ref var dataComponent = ref _applyingDataPool.Get(targetEntity);
                if(!dataComponent.Source.Unpack(_world,out var sourceEntity))
                    continue;

                ref var targetMaterialData = ref _materialDataPool.Get(targetEntity);
                ref var sourceMaterialData = ref _materialDataPool.Get(sourceEntity);

                ref var progressComponent = ref _progressPool.Get(targetEntity);

                var targetMaterial = targetMaterialData.Value;
                var sourceMaterial = sourceMaterialData.Value;
                
                targetMaterialData.Value.Lerp(targetMaterial,sourceMaterial,progressComponent.Value);
            }
        }
    }
}