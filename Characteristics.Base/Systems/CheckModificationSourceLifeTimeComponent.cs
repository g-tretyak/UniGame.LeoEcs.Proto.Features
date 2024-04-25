namespace unigame.ecs.proto.Characteristics.Base.Systems
{
    using System;
    using Components;
    using Components.Requests;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// check modifications is tracked modification source is dead, then remove modification
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class CheckModificationSourceLifeTimeComponent : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private ProtoPool<ModificationSourceLinkComponent> _sourceLinkPool;
        private ProtoPool<CharacteristicLinkComponent> _characteristicsLinkPool;
        private ProtoPool<RecalculateCharacteristicSelfRequest> _recalculateSelfPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world.Filter<ModificationComponent>()
                .Inc<ModificationSourceTrackComponent>()
                .Inc<CharacteristicLinkComponent>()
                .Inc<ModificationSourceLinkComponent>()
                .End();

            _sourceLinkPool = _world.GetPool<ModificationSourceLinkComponent>();
            _characteristicsLinkPool = _world.GetPool<CharacteristicLinkComponent>();
            _recalculateSelfPool = _world.GetPool<RecalculateCharacteristicSelfRequest>();
            
        }

        public void Run()
        {
            foreach (var modification in _filter)
            {
                ref var ownerLinkComponent = ref _sourceLinkPool.Get(modification);
                if (ownerLinkComponent.Value.Unpack(_world,out var sourceEntity))
                    continue;

                ref var characteristicsLinkComponent = ref _characteristicsLinkPool.Get(modification);

                if (characteristicsLinkComponent.Link.Unpack(_world, out var characteristicEntity))
                {
                    ref var recalculateRequest = ref _recalculateSelfPool.GetOrAddComponent(characteristicEntity);
                }
                
                _world.DelEntity(modification);
            }
        }
    }
}