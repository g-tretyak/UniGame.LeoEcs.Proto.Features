﻿namespace UniGame.Ecs.Proto.Characteristics.AttackSpeed.Components
{
    using System;

    /// <summary>
    /// attack speed characteristic
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct AttackSpeedComponent
    {
        public float Value;
    }
}