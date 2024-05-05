namespace UniGame.Ecs.Proto.Characteristics.Health
{
    using System;
    using Base;
    using Base.Aspects;
    using Base.Components;
    using Cysharp.Threading.Tasks;
    using Feature;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using LeoEcs.Shared.Extensions;
    using UnityEngine;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

    /// <summary>
    /// new characteristic feature: Health 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Characteristics/Health")]
    public sealed class HealthFeature : CharacteristicFeature<HealthEcsFeature>
    {

    }

    /// <summary>
    /// new characteristic feature: Health 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class HealthEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            //register Health characteristic
            ecsSystems.AddCharacteristic<HealthComponent>();
            //update Health by request
            ecsSystems.Add(new ProcessHealthChangedSystem());

            return UniTask.CompletedTask;
        }
    }

    /// <summary>
    /// characteristic Health aspect data
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class HealthAspect : GameCharacteristicAspect<HealthComponent>
    {

    }

    /// <summary>
    /// Health characteristic component
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct HealthComponent
    {
        /// <summary>
        /// Current value of characteristic.
        /// </summary>
        public float Value;

        /// <summary>
        /// Max value of characteristic.
        /// </summary>
        public float MaxValue;

        /// <summary>
        /// Min value of characteristic.
        /// </summary>
        public float MinValue;

        /// <summary>
        /// Base value of characteristic.
        /// </summary>
        public float BaseValue;
    }

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ProcessHealthChangedSystem : IProtoRunSystem
    {
        private HealthAspect _HealthAspect;

        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<HealthComponent>>()
            .Inc<CharacteristicComponent<HealthComponent>>()
            .Inc<HealthComponent>()
            .End();

        private ProtoWorld _world;

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _HealthAspect.Value.Get(entity);
                ref var HealthComponent = ref _HealthAspect.Characteristic.Get(entity);
                HealthComponent.Value = characteristicComponent.Value;
                HealthComponent.MaxValue = characteristicComponent.MaxValue;
                HealthComponent.MinValue = characteristicComponent.MinValue;
                HealthComponent.BaseValue = characteristicComponent.BaseValue;
            }
        }
    }

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class HealthComponentConverter : GameCharacteristicConverter<HealthComponent>
    {

    }
}