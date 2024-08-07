namespace UniGame.Ecs.Proto.Characteristics.Shield.Systems
{
    using System;
    using Aspects;
    using Base.Components.Events;
    using Components;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// System that resets the shield of entities.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ResetShieldSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private ShieldCharacteristicAspect _aspect;

        private ProtoIt _filter = It
            .Chain<ShieldComponent>()
            .Inc<ResetCharacteristicsEvent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                _aspect.Shield.Del(entity);
            }
        }
    }
}