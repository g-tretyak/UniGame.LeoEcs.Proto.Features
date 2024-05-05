namespace UniGame.Ecs.Proto.Characteristics.Speed
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
    /// new characteristic feature: Speed 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Characteristics/Speed")]
    public sealed class SpeedFeature : CharacteristicFeature<SpeedEcsFeature>
    {

    }

    /// <summary>
    /// new characteristic feature: Speed 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class SpeedEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            //register Speed characteristic
            ecsSystems.AddCharacteristic<SpeedComponent>();
            //update Speed by request
            ecsSystems.Add(new ProcessSpeedChangedSystem());

            return UniTask.CompletedTask;
        }
    }

    /// <summary>
    /// characteristic Speed aspect data
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class SpeedAspect : GameCharacteristicAspect<SpeedComponent>
    {

    }

    /// <summary>
    /// Speed characteristic component
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct SpeedComponent
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
    public sealed class ProcessSpeedChangedSystem : IProtoRunSystem
    {
        private SpeedAspect _SpeedAspect;

        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<SpeedComponent>>()
            .Inc<CharacteristicComponent<SpeedComponent>>()
            .Inc<SpeedComponent>()
            .End();

        private ProtoWorld _world;

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _SpeedAspect.Value.Get(entity);
                ref var SpeedComponent = ref _SpeedAspect.Characteristic.Get(entity);
                SpeedComponent.Value = characteristicComponent.Value;
                SpeedComponent.MaxValue = characteristicComponent.MaxValue;
                SpeedComponent.MinValue = characteristicComponent.MinValue;
                SpeedComponent.BaseValue = characteristicComponent.BaseValue;
            }
        }
    }

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class SpeedComponentConverter : GameCharacteristicConverter<SpeedComponent>
    {

    }
}