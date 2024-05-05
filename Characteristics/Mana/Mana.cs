namespace UniGame.Ecs.Proto.Characteristics.Mana
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
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

    /// <summary>
    /// new characteristic feature: Mana 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Characteristics/Mana")]
    public sealed class ManaFeature : CharacteristicFeature<ManaEcsFeature>
    {

    }

    /// <summary>
    /// new characteristic feature: Mana 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class ManaEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            //register Mana characteristic
            ecsSystems.AddCharacteristic<ManaComponent>();
            //update Mana by request
            ecsSystems.Add(new ProcessManaChangedSystem());

            return UniTask.CompletedTask;
        }
    }

    /// <summary>
    /// characteristic Mana aspect data
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ManaAspect : GameCharacteristicAspect<ManaComponent>
    {

    }

    /// <summary>
    /// Mana characteristic component
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct ManaComponent
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
    public sealed class ProcessManaChangedSystem : IProtoRunSystem
    {
        private ManaAspect _ManaAspect;

        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<ManaComponent>>()
            .Inc<CharacteristicComponent<ManaComponent>>()
            .Inc<ManaComponent>()
            .End();

        private ProtoWorld _world;

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _ManaAspect.Value.Get(entity);
                ref var ManaComponent = ref _ManaAspect.Characteristic.Get(entity);
                ManaComponent.Value = characteristicComponent.Value;
                ManaComponent.MaxValue = characteristicComponent.MaxValue;
                ManaComponent.MinValue = characteristicComponent.MinValue;
                ManaComponent.BaseValue = characteristicComponent.BaseValue;
            }
        }
    }

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ManaComponentConverter : GameCharacteristicConverter<ManaComponent>
    {

    }
}