namespace UniGame.Ecs.Proto.Characteristics.Radius.Component
{
    using System;

    /// <summary>
    /// Component that stores the radius value.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct RadiusComponent
    {
        public float Value;
    }
}