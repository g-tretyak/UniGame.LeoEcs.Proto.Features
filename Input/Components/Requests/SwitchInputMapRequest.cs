namespace Game.Ecs.Input.Components.Requests
{
    using System;
    using Data.ActionMap;

    /// <summary>
    /// Request component used to signal the system to switch to a different input map.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct SwitchInputMapRequest
    {
        public InputActionsMapId actionsMapId;
    }
}