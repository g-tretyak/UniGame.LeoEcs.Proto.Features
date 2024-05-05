namespace UniGame.Ecs.Proto.Characteristics.AttackDamage
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
    /// new characteristic feature: AttackDamage 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Characteristics/AttackDamage")]
    public sealed class AttackDamageFeature : CharacteristicFeature<AttackDamageEcsFeature>
    {

    }

    /// <summary>
    /// new characteristic feature: AttackDamage 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class AttackDamageEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            //register AttackDamage characteristic
            ecsSystems.AddCharacteristic<AttackDamageComponent>();
            //update AttackDamage by request
            ecsSystems.Add(new ProcessAttackDamageChangedSystem());

            return UniTask.CompletedTask;
        }
    }

    /// <summary>
    /// characteristic AttackDamage aspect data
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class AttackDamageAspect : GameCharacteristicAspect<AttackDamageComponent>
    {

    }

    /// <summary>
    /// AttackDamage characteristic component
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct AttackDamageComponent
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
    public sealed class ProcessAttackDamageChangedSystem : IProtoRunSystem
    {
        private AttackDamageAspect _AttackDamageAspect;

        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<AttackDamageComponent>>()
            .Inc<CharacteristicComponent<AttackDamageComponent>>()
            .Inc<AttackDamageComponent>()
            .End();

        private ProtoWorld _world;

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _AttackDamageAspect.Value.Get(entity);
                ref var AttackDamageComponent = ref _AttackDamageAspect.Characteristic.Get(entity);
                AttackDamageComponent.Value = characteristicComponent.Value;
                AttackDamageComponent.MaxValue = characteristicComponent.MaxValue;
                AttackDamageComponent.MinValue = characteristicComponent.MinValue;
                AttackDamageComponent.BaseValue = characteristicComponent.BaseValue;
            }
        }
    }

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class AttackDamageComponentConverter : GameCharacteristicConverter<AttackDamageComponent>
    {

    }
}