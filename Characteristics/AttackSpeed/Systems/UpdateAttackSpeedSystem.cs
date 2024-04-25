namespace unigame.ecs.proto.Characteristics.AttackSpeed.Systems
{
    using System;
    using Components;
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
    public sealed class UpdateAttackSpeedChangedSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<CharacteristicComponent<AttackSpeedComponent>> _characteristicPool;
        private ProtoPool<AttackSpeedComponent> _attackSpeed;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CharacteristicChangedComponent<AttackSpeedComponent>>()
                .Inc<CharacteristicComponent<AttackSpeedComponent>>()
                .Inc<AttackSpeedComponent>()
                .Inc<AttackSpeedCooldownTypeComponent>()
                .End();

            _characteristicPool = _world.GetPool<CharacteristicComponent<AttackSpeedComponent>>();
            _attackSpeed = _world.GetPool<AttackSpeedComponent>();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _characteristicPool.Get(entity);
                ref var attackSpeedComponent = ref _attackSpeed.Get(entity);
                attackSpeedComponent.Value = characteristicComponent.Value;
            }
        }
    }
}