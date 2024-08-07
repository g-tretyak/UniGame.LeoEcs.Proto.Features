namespace UniGame.Ecs.Proto.Characteristics.Speed.Systems
{
    using System;
    using Aspects;
    using Base.Components;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// System for processing speed changes in entities.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ProcessSpeedChangedSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private SpeedAspect _speedAspect;

        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<SpeedComponent>>()
            .Inc<CharacteristicComponent<SpeedComponent>>()
            .Inc<SpeedComponent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _speedAspect.Value.Get(entity);
                ref var speedComponent = ref _speedAspect.Characteristic.Get(entity);
                speedComponent.Value = characteristicComponent.Value;
                speedComponent.MaxValue = characteristicComponent.MaxValue;
                speedComponent.MinValue = characteristicComponent.MinValue;
                speedComponent.BaseValue = characteristicComponent.BaseValue;
            }
        }
    }
}