namespace UniGame.Ecs.Proto.Characteristics.AttackSpeed.Aspects
{
    using System;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Leopotam.EcsProto;

    /// <summary>
    /// Aspect representing the Attack Speed characteristic for a feature.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class AttackSpeedCharacteristicAspect : GameCharacteristicAspect<AttackSpeedComponent>
    {
        public ProtoPool<AttackSpeedComponent> AttackSpeed;
        public ProtoPool<AttackAbilityIdComponent> AttackAbilityId;
        public ProtoPool<AttackSpeedCooldownTypeComponent> CooldownType;
        public ProtoPool<CharacteristicComponent<AttackSpeedComponent>> AttackSpeedCharacteristic;
        
    }
}