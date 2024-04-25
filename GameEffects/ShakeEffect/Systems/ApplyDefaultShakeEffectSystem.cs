namespace unigame.ecs.proto.GameEffects.ShakeEffect.Systems
{
    using System;
    using Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;

    /// <summary>
    /// start shake effect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class ApplyDefaultShakeEffectSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _cameraFilter;
        private EcsFilter _shakeFilter;

        private ProtoPool<ShakeEffectTargetComponent> _targetPool;
        private ProtoPool<ShakeEffectDataComponent> _dataPool;
        private ProtoPool<TransformComponent> _transformPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _cameraFilter = _world
                .Filter<ShakeEffectDefaultTargetComponent>()
                .Inc<TransformComponent>()
                .End();

            _shakeFilter = _world
                .Filter<ShakeEffectDataComponent>()
                .Exc<ShakeEffectTargetComponent>()
                .End();
            
        }

        public void Run()
        {
            foreach (var shakeEntity in _shakeFilter)
            {
                foreach (var targetEntity in _cameraFilter)
                {
                    var requestEntity = _world.NewEntity();

                    ref var targetComponent = ref _targetPool.Add(requestEntity);
                    ref var targetData = ref _dataPool.Add(requestEntity);
                    
                    _dataPool.Copy(shakeEntity,requestEntity);
                    
                    ref var transformComponent = ref _transformPool.Get(targetEntity);
                    targetComponent.Value = transformComponent.Value;
                }
            }
        }
    }
}