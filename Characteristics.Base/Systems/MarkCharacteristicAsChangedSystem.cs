namespace UniGame.Ecs.Proto.Characteristics.Base.Systems
{
    using System;
    using Components;
    using Components.Requests;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    /// <summary>
    /// get RecalculateCharacteristicSelfRequest and mark characteristic as changed
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class MarkCharacteristicAsChangedSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        
        private ProtoPool<CharacteristicChangedComponent> _changedPool;


        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world
                .Filter<RecalculateCharacteristicSelfRequest>()
                .Inc<CharacteristicValueComponent>()
                .Inc<CharacteristicBaseValueComponent>()
                .Exc<CharacteristicChangedComponent>()
                .End();
            
            _changedPool = _world.GetPool<CharacteristicChangedComponent>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                _changedPool.Add(entity);
            }
        }
    }
}