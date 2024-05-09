namespace Game.Ecs.Input.Components
{
    using System;
    using Leopotam.EcsLite;
    using UnityEngine.InputSystem;

    /// <summary>
    /// Component representing an input actions.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct InputActionsComponent : IEcsAutoReset<InputActionsComponent>
    {
        public DefaultInputActions InputActions;
        
        public void AutoReset(ref InputActionsComponent c)
        {
            c.InputActions = new DefaultInputActions();
        }
    }
}