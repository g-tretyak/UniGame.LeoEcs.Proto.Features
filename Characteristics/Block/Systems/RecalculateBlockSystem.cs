namespace UniGame.Ecs.Proto.Characteristics.Block.Systems
{
    using System;
    using Aspects;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.Ecs.Proto.Characteristics.Base.Components;

    /// <summary>
    /// update value of attack speed characteristic
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class RecalculateBlockSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private BlockAspect _aspect;
        
        private ProtoIt _filter = It
            .Chain<CharacteristicChangedComponent<BlockComponent>>()
            .Inc<CharacteristicComponent<BlockComponent>>()
            .Inc<BlockComponent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var characteristicComponent = ref _aspect.BlockCharacteristic.Get(entity);
                ref var valueComponent = ref _aspect.Block.Get(entity);
                valueComponent.Value = characteristicComponent.Value;
            }
        }
    }
}