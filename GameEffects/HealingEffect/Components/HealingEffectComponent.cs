namespace UniGame.Ecs.Proto.GameEffects.HealingEffect.Components
{
    using System;

    /// <summary>
    /// Represents a healing effect component.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct HealingEffectComponent
    {
        public float Value;
    }
}