namespace UniGame.Ecs.Proto.Characteristics.Mana.Aspects
{
    using System;
    using Base.Aspects;
    using Components;
    using Leopotam.EcsLite;

    /// <summary>
    /// characteristic Mana aspect data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ManaAspect : GameCharacteristicAspect<ManaComponent>
    {
        public EcsPool<ManaComponent> Mana;
    }
}