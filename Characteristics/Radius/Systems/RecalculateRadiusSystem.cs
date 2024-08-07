namespace UniGame.Ecs.Proto.Characteristics.Radius.Systems
{
    using System;
    using Base.Components;
    using Component;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// System that recalculates the radius value for entities.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class RecalculateRadiusSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private RadiusCharacteristicAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<RadiusComponent>>()
            .Inc<CharacteristicComponent<RadiusComponent>>()
            .Inc<RadiusComponent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _aspect.RadiusCharacteristic.Get(entity);
                ref var characteristicValueComponent = ref _aspect.Radius.Get(entity);
                characteristicValueComponent.Value = characteristicComponent.Value;
            }
        }
    }
}