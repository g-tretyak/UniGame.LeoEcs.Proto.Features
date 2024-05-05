namespace UniGame.Ecs.Proto.Characteristics.ManaRegeneration
{
    using System;
    using System.Threading;
    using Base;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Cysharp.Threading.Tasks;
    using Feature;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using LeoEcs.Shared.Extensions;
    using Sirenix.OdinInspector;
    using Systems;
    using UnityEngine;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

    /// <summary>
    /// new characteristic feature: ManaRegeneration 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [CreateAssetMenu(menuName = "Proto Features/Characteristics/ManaRegeneration")]
    public sealed class ManaRegenerationFeature : CharacteristicFeature<ManaRegenerationEcsFeature>
    {

    }

    /// <summary>
    /// new characteristic feature: ManaRegeneration 
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class ManaRegenerationEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            //register ManaRegeneration characteristic
            ecsSystems.AddCharacteristic<ManaRegenerationComponent>();
            //update ManaRegeneration by request
            ecsSystems.Add(new ProcessManaRegenerationChangedSystem());
            
            // Mana regeneration. Uses request ChangeManaRequest when you want to change mana value.
            // Inside uses a timer. 
            ecsSystems.Add(new ProcessManaRegenerationSystem());
            
            return UniTask.CompletedTask;
        }
    }

    /// <summary>
    /// characteristic ManaRegeneration aspect data
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ManaRegenerationAspect : GameCharacteristicAspect<ManaRegenerationComponent>
    {
        public ProtoPool<ManaRegenerationTimerComponent> RegenerationTimer;
    }

    /// <summary>
    /// ManaRegeneration characteristic component
    /// </summary>
    [Serializable]
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public struct ManaRegenerationComponent
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
    public sealed class ProcessManaRegenerationChangedSystem : IProtoRunSystem
    {
        private ManaRegenerationAspect _ManaRegenerationAspect;

        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<ManaRegenerationComponent>>()
            .Inc<CharacteristicComponent<ManaRegenerationComponent>>()
            .Inc<ManaRegenerationComponent>()
            .End();

        private ProtoWorld _world;

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _ManaRegenerationAspect.Value.Get(entity);
                ref var ManaRegenerationComponent = ref _ManaRegenerationAspect.Characteristic.Get(entity);
                ManaRegenerationComponent.Value = characteristicComponent.Value;
                ManaRegenerationComponent.MaxValue = characteristicComponent.MaxValue;
                ManaRegenerationComponent.MinValue = characteristicComponent.MinValue;
                ManaRegenerationComponent.BaseValue = characteristicComponent.BaseValue;
            }
        }
    }

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class ManaRegenerationComponentConverter : GameCharacteristicConverter<ManaRegenerationComponent>
    {
        [ShowInInspector, PropertyRange(0f, 1f)]
        public float tickTime = 0.2f;

        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var manaRegenerationTimerComponent = ref world.AddComponent<ManaRegenerationTimerComponent>(entity);
            manaRegenerationTimerComponent.TickTime = tickTime;
            manaRegenerationTimerComponent.LastTickTime = Time.time;
        }
    }
}