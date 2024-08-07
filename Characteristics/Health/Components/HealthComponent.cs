namespace UniGame.Ecs.Proto.Characteristics.Health.Components
{
    using System;

    /// <summary>
    /// Health characteristic component
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct HealthComponent
    {
        /// <summary>
        /// Current value of characteristic.
        /// </summary>
        public float Value;

        /// <summary>
        /// Max value of characteristic.
        /// </summary>
        public float MaxValue;

        /// <summary>
        /// Min value of characteristic.
        /// </summary>
        public float MinValue;

        /// <summary>
        /// Base value of characteristic.
        /// </summary>
        public float BaseValue;
    }
}