namespace UniGame.Ecs.Proto.Characteristics.ManaRegeneration.Systems
{
    using System;
    using Aspects;
    using Base.Components;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// System that handles the regeneration of mana characteristic.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ProcessManaRegenerationChangedSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private ManaRegenerationAspect _manaRegenerationAspect;

        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<ManaRegenerationComponent>>()
            .Inc<CharacteristicComponent<ManaRegenerationComponent>>()
            .Inc<ManaRegenerationComponent>()
            .End();


        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _manaRegenerationAspect.Value.Get(entity);
                ref var manaRegenerationComponent = ref _manaRegenerationAspect.Characteristic.Get(entity);
                manaRegenerationComponent.Value = characteristicComponent.Value;
                manaRegenerationComponent.MaxValue = characteristicComponent.MaxValue;
                manaRegenerationComponent.MinValue = characteristicComponent.MinValue;
                manaRegenerationComponent.BaseValue = characteristicComponent.BaseValue;
            }
        }
    }
}