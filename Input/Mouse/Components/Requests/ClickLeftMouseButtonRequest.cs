namespace Game.Ecs.Input.Mouse.Components.Requests
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Request component used to signal the system to process a left mouse button click.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ClickLeftMouseButtonRequest
    {
        public Vector2 MousePosition;
        public string ActionName;
    }
}