﻿namespace UniGame.Ecs.Proto.Characteristics.AbilityPower.Components
{
    using System;

    /// <summary>
    /// Ability Power value
    /// </summary>
#if ENABLE_IL2CPP
	using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct AbilityPowerComponent
    {
        public float Value;
    }
}