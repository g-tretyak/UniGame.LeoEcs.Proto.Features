namespace UniGame.Ecs.Proto.Characteristics
{
    using System;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct Modification
    {
        public float baseValue;
        public int counter;
        public bool isPercent;
        public bool isMaxLimitModification;
        public bool allowedSummation;

        public Modification(
            float modificationValue, 
            bool isPercent,
            bool allowedSummation, 
            bool isMaxLimitModification,
            int counter = 1)
        {
            this.baseValue = modificationValue;
            this.isPercent = isPercent;
            this.allowedSummation = allowedSummation;
            this.isMaxLimitModification = isMaxLimitModification;
            this.counter = counter;
        }
    }
}