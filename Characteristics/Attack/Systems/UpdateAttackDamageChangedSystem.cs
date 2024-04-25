namespace unigame.ecs.proto.Characteristics.Attack.Systems
{
    using System;
    using unigame.ecs.proto.Characteristics.Attack.Components;
    using unigame.ecs.proto.Characteristics.Base.Components;
     

    /// <summary>
    /// update value of attack speed characteristic
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class UpdateAttackDamageChangedSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<CharacteristicComponent<AttackDamageComponent>> _characteristicPool;
        private ProtoPool<AttackDamageComponent> _valuePool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CharacteristicChangedComponent<AttackDamageComponent>>()
                .Inc<CharacteristicComponent<AttackDamageComponent>>()
                .Inc<AttackDamageComponent>()
                .End();

            _characteristicPool = _world.GetPool<CharacteristicComponent<AttackDamageComponent>>();
            _valuePool = _world.GetPool<AttackDamageComponent>();
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