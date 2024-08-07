namespace UniGame.Ecs.Proto.Characteristics.SplashDamage.Systems
{
    using System;
    using Aspects;
    using Base.Components;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// Recalculates Splash Damage value.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class RecalculateSplashDamageSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private SplashDamageAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<SplashDamageComponent>>()
            .Inc<CharacteristicComponent<SplashDamageComponent>>()
            .Inc<SplashDamageComponent>()
            .End();

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _aspect.SplashDamageCharacteristic.Get(entity);
                ref var valueComponent = ref _aspect.SplashDamage.Get(entity);
                valueComponent.Value = characteristicComponent.Value;
            }
        }
    }
}