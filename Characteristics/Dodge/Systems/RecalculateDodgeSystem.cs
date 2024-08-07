namespace UniGame.Ecs.Proto.Characteristics.Dodge.Systems
{
    using System;
    using Aspects;
    using Base.Components;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// System used to recalculate the dodge value for entities.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class RecalculateDodgeSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private DodgeCharacteristicAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<DodgeComponent>>()
            .Inc<CharacteristicComponent<DodgeComponent>>()
            .Inc<DodgeComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _aspect.DodgeDodgeCharacteristic.Get(entity);
                ref var valueComponent = ref _aspect.Dodge.Get(entity);
                valueComponent.Value = characteristicComponent.Value;
            }
        }
    }
}