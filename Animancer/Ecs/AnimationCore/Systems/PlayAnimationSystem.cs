using System;
using Animancer;
using Game.Code.Services.Animation;
using Game.Code.Services.Animation.Data.AnimnationsData;
using Game.Ecs.Animation.AnimationCore.Aspects;
using Game.Ecs.Animation.AnimationCore.Components;
using Game.Ecs.Animation.AnimationCore.Components.Requests;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
using UniGame.LeoEcs.Shared.Extensions;

namespace Game.Ecs.Animation.AnimationCore.Systems
{
    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class PlayAnimationSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private AnimationCoreAspect _animationCoreAspect;
        private IAnimationService _animationService;
        
        private ProtoIt  _animancersFilter = It.Chain<AnimancerAnimatorComponent>().End();
        private ProtoIt _playAnimationRequestFilter = It.Chain<PlayAnimationWithActorRequest>().End();

        public PlayAnimationSystem(IAnimationService animationService)
        {
            _animationService = animationService;
        }

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
        }

        public void Run()
        {
            foreach (var requestEntity in _playAnimationRequestFilter)
            {
                ref var playAnimationRequest = ref _animationCoreAspect.PlayAnimationWithActorRequest.Get(requestEntity);
                if (!playAnimationRequest.ActorEntity.Unpack(_world, out var animancerEntity)) continue;

                ref var animancerAnimatorComponent = ref _animationCoreAspect.AnimancerAnimator.Get(animancerEntity);

                var animationEntry = _animationService.GetAnimationEntry(playAnimationRequest.ActorType, playAnimationRequest.AnimationType);
                if (animationEntry == null) continue;

                var animancerComponent = animancerAnimatorComponent.AnimancerComponent;
                if (animancerComponent.States.TryGet(animationEntry.Animation, out var state))
                {
                    if ( state.IsPlaying) continue;
                    
                    PlayAnimation(animancerComponent, animationEntry, animancerEntity);
                    continue;
                }

                PlayAnimation(animancerComponent, animationEntry, animancerEntity);
            }
        }
        
        private void PlayAnimation(AnimancerComponent animancerComponent, AnimationEntry animationEntry, ProtoEntity animancerEntity)
        {
            AnimancerState state;
            state = animancerComponent.Play(animationEntry.Animation);
            SetupEventsForAnimancerIfAny(animancerEntity, animationEntry, state);
        }

        private void SetupEventsForAnimancerIfAny(ProtoEntity animancerEntity, AnimationEntry animationEntry, AnimancerState state)
        {
            AnimancerEvent.Sequence events;
            if (_animationCoreAspect.AnimationsEvents.Has(animancerEntity))
            {
                ref var animationsEventComponent = ref _animationCoreAspect.AnimationsEvents.Get(animancerEntity);
                events = GetEventsForAnimation(animationsEventComponent, animationEntry);
                state.Events = events;
            }
        }

        private AnimancerEvent.Sequence GetEventsForAnimation(AnimationsEventsComponent animationsEventComponent, AnimationEntry animationEntry)
        {
            var indexOfAnimationEntry = animationsEventComponent.AnimationEntries.FindIndex(x => x == animationEntry);
            if (indexOfAnimationEntry == -1) return null;
            
            return animationsEventComponent.Events[indexOfAnimationEntry];
        }
    }
}