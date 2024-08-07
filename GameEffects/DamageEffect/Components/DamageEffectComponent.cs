﻿namespace UniGame.Ecs.Proto.GameEffects.DamageEffect.Components
{
    using System;

    /// <summary>
    /// Component that holds information about a damage effect.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct DamageEffectComponent
    {
        public float Value;
    }
}