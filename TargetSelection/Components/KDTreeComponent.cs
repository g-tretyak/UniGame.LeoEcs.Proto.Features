﻿namespace UniGame.Ecs.Proto.TargetSelection.Components
{
    using System;
    using DataStructures.ViliWonka.KDTree;
    /// <summary>
    /// KD Tree component
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct KDTreeComponent
    {
        public KDTree Value;
    }
}