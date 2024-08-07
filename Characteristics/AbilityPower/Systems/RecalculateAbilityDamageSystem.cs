namespace UniGame.Ecs.Proto.Characteristics.AbilityPower.Systems
{
    using System;
    using Aspects;
    using Base.Components;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// Recalculates Ability Damage value.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class RecalculateAbilityPowerSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private AbilityPowerCharacteristicAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<AbilityPowerComponent>>()
            .Inc<CharacteristicComponent<AbilityPowerComponent>>()
            .Inc<AbilityPowerComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _aspect.AbilityPowerCharacteristic.Get(entity);
                ref var valueComponent = ref _aspect.AbilityPower.Get(entity);
                valueComponent.Value = characteristicComponent.Value;
            }
        }
    }
}