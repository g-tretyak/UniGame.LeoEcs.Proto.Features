namespace UniGame.Ecs.Proto.Characteristics.CriticalChance.Systems
{
    using System;
    using Aspects;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.Ecs.Proto.Characteristics.Base.Components;

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
    [ECSDI]
    public sealed class UpdateCriticalChanceChangedSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private CriticalChanceAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<CriticalChanceComponent>>()
            .Inc<CharacteristicComponent<CriticalChanceComponent>>()
            .Inc<CriticalChanceComponent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _aspect.CriticalChanceCharacteristic.Get(entity);
                ref var valueComponent = ref _aspect.CriticalChance.Get(entity);
                valueComponent.Value = characteristicComponent.Value;
            }
        }
    }
}