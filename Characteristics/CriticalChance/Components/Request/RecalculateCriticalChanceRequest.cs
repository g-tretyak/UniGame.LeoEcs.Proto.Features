namespace UniGame.Ecs.Proto.Characteristics.Attack.Components
{
    using System;

    /// <summary>
    /// Request to recalculate the critical chance for a character's attack.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct RecalculateCriticalChanceRequest
    {
    }
}