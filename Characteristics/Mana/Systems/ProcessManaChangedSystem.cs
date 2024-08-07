namespace UniGame.Ecs.Proto.Characteristics.Mana.Systems
{
    using System;
    using Aspects;
    using Base.Components;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// System that processes changes in the mana characteristic of entities.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ProcessManaChangedSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private ManaAspect _manaAspect;

        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<ManaComponent>>()
            .Inc<CharacteristicComponent<ManaComponent>>()
            .Inc<ManaComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _manaAspect.Value.Get(entity);
                ref var manaComponent = ref _manaAspect.Characteristic.Get(entity);
                manaComponent.Value = characteristicComponent.Value;
                manaComponent.MaxValue = characteristicComponent.MaxValue;
                manaComponent.MinValue = characteristicComponent.MinValue;
                manaComponent.BaseValue = characteristicComponent.BaseValue;
            }
        }
    }
}