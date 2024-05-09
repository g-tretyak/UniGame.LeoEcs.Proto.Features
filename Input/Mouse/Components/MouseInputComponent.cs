namespace Game.Ecs.Input.Mouse.Components
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Component indicating subscribed to mouse input events.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct MouseInputComponent
    {
        public Vector2 MousePosition;
    }
}