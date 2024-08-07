namespace UniGame.Ecs.Proto.Characteristics.Block.Aspects
{
    using System;
    using Base.Aspects;
    using Base.Components;
    using Components;
    using Leopotam.EcsProto;

    /// <summary>
    /// Aspect representing the Block characteristic for a feature.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public sealed class BlockAspect : GameCharacteristicAspect<BlockComponent>
    {
        public ProtoPool<BlockComponent> Block;
        public ProtoPool<CharacteristicComponent<BlockComponent>> BlockCharacteristic;
    }
}