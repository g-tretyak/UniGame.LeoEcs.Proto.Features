namespace UniGame.Ecs.Proto.Characteristics.Duration.Components
{
    using System;

    /// <summary>
    /// Component that stores the duration for an ability or effect.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct DurationComponent
    {
        public float Value;
    }
}