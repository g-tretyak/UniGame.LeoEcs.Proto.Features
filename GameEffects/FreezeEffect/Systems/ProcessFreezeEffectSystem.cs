namespace UniGame.Ecs.Proto.GameEffects.FreezeEffect.Systems
{
    using Ability.Common.Components;
    using Components;
    using Game.Code.Timeline;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// Stops animation and ability
    /// </summary>

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public class ProcessFreezeEffectSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private ProtoPool<FreezeTargetEffectComponent> _freezeTargetEffectPool;
        private ProtoPool<RemoveFreezeTargetEffectRequest> _removeFreezeTargetEffectPool;
        private ProtoPool<PlayableDirectorComponent> _playableDirectorPool;
        private ProtoPool<AbilityMapComponent> _abilityMapPool;
        private ProtoPool<PauseAbilityRequest> _pauseAbilityRequestPool;
        private ProtoPool<RemovePauseAbilityRequest> _removePauseAbilityRequestPool;
        private ProtoPool<PrepareToDeathComponent> _prepareToDeathPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<FreezeTargetEffectComponent>()
                .Inc<PlayableDirectorComponent>()
                .Inc<AbilityMapComponent>()
                .End();
            _freezeTargetEffectPool = _world.GetPool<FreezeTargetEffectComponent>();
            _removeFreezeTargetEffectPool = _world.GetPool<RemoveFreezeTargetEffectRequest>();
            _playableDirectorPool = _world.GetPool<PlayableDirectorComponent>();
            _abilityMapPool = _world.GetPool<AbilityMapComponent>();
            _pauseAbilityRequestPool = _world.GetPool<PauseAbilityRequest>();
            _removePauseAbilityRequestPool = _world.GetPool<RemovePauseAbilityRequest>();
            _prepareToDeathPool = _world.GetPool<PrepareToDeathComponent>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var freezeTargetEffectComponent = ref _freezeTargetEffectPool.Get(entity);
                ref var abilityComponent = ref _abilityMapPool.Get(entity);
                ref var playableDirectorComponent = ref _playableDirectorPool.Get(entity);
                var playableDirector = playableDirectorComponent.Value;
                if (!playableDirector)
                    continue;
                var dumpTime = freezeTargetEffectComponent.DumpTime;
                if (Time.time >= dumpTime || Mathf.Approximately(dumpTime, Time.time) || _prepareToDeathPool.Has(entity))
                {
                    var requestEntity = _world.NewEntity();
                    ref var requestComponent = ref _removeFreezeTargetEffectPool.Add(requestEntity);
                    requestComponent.Target = _world.PackEntity(entity);

                    playableDirector.SetRootSpeed(1);
                    
                    foreach (var ability in abilityComponent.AbilityEntities)
                    {
                        ref var request = ref _removePauseAbilityRequestPool.Add(_world.NewEntity());
                        request.AbilityEntity = ability;
                    }
                    continue;
                }
                
                foreach (var ability in abilityComponent.AbilityEntities)
                {
                    ref var request = ref _pauseAbilityRequestPool.Add(_world.NewEntity());
                    request.AbilityEntity = ability;
                }

                playableDirector.SetRootSpeed(0);
            }
        }
    }
}