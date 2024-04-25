namespace unigame.ecs.proto.Presets.Systems
{
    using System;
    using Components;
     
    
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif


    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public class DisableActivatedPresetsSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _sourceFilter;
        
        private ProtoPool<ActivePresetSourceComponent> _activePool;
        private ProtoPool<PresetActivatedComponent> _activatedPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _sourceFilter = _world
                .Filter<PresetComponent>()
                .Inc<ActivePresetSourceComponent>()
                .Inc<PresetActivatedComponent>()
                .End();

            _activePool = _world.GetPool<ActivePresetSourceComponent>();
            _activatedPool = _world.GetPool<PresetActivatedComponent>();
        }

        public void Run()
        {
            foreach (var sourceEntity in _sourceFilter)
            {
                _activePool.Del(sourceEntity);
                _activatedPool.Del(sourceEntity);
                    
                break;
            }
        }
    }
}