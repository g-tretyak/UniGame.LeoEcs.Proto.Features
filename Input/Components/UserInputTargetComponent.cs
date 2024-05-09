﻿namespace Game.Ecs.Input.Components
{
    using System;

    /// <summary>
    /// input main target
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct UserInputTargetComponent
    {
        public int Id;
    }
}