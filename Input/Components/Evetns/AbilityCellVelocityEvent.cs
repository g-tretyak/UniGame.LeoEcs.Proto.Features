namespace Game.Ecs.Input.Components.Evetns
{
    using System;
    using Unity.Mathematics;

    /// <summary>
    /// ability velocity event.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct AbilityCellVelocityEvent
    {
        public int Id;
        public float3 Value;
    }
}