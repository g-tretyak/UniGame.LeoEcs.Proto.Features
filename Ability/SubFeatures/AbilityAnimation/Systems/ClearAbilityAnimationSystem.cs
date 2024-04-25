namespace unigame.ecs.proto.Ability.SubFeatures.AbilityAnimation.Systems
{
    using System;
    using Animations.Aspects;
    using Aspects;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using unigame.ecs.proto.Ability.Common.Components;
    using unigame.ecs.proto.Core.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ClearAbilityAnimationSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private AbilityAnimationAspect _abilityAnimationAspect;
        private AnimationTimelineAspect _animationAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<CompleteAbilitySelfRequest>()
                .Inc<AnimationLinkComponent>()
                .Inc<OwnerComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var activeAnimationComponent = ref _abilityAnimationAspect.ActiveAnimation.Get(entity);
                ref var ownerComponent = ref _abilityAnimationAspect.Owner.Get(entity);
                
                if(!ownerComponent.Value.Unpack(_world, out var ownerEntity)) continue;
                if(!activeAnimationComponent.Value.Unpack(_world,out var animationEntity)) continue;
                
                if(!_abilityAnimationAspect.Data.Has(animationEntity)) continue;
                if(!_abilityAnimationAspect.Director.Has(ownerEntity)) continue;

                _animationAspect.StopSelf.GetOrAddComponent(animationEntity);
            }
        }
    }
}