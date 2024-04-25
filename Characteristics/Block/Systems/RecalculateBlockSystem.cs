namespace unigame.ecs.proto.Characteristics.Block.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using unigame.ecs.proto.Characteristics.Base.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.IL2CPP.CompilerServices;

    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class RecalculateBlockSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<CharacteristicComponent<BlockComponent>> _characteristicPool;
        private ProtoPool<BlockComponent> _valuePool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CharacteristicChangedComponent<BlockComponent>>()
                .Inc<CharacteristicComponent<BlockComponent>>()
                .Inc<BlockComponent>()
                .End();

            _characteristicPool = _world.GetPool<CharacteristicComponent<BlockComponent>>();
            _valuePool = _world.GetPool<BlockComponent>();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _characteristicPool.Get(entity);
                ref var valueComponent = ref _valuePool.Get(entity);
                valueComponent.Value = characteristicComponent.Value;
            }
        }
    }
}