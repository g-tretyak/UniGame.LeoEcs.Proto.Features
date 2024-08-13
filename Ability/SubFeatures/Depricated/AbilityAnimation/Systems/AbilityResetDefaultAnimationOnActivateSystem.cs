namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilityAnimation.Systems
{
    using System;
    using Animations.Components;
    using Aspects;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.Ecs.Proto.Ability.Common.Components;
    using UniGame.Ecs.Proto.Core.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// reset ability animation to default state when ability activated
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class AbilityResetDefaultAnimationOnActivateSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        
        private AbilityAnimationAspect _animationAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<AbilityStartUsingSelfEvent>()
                .Inc<OwnerComponent>()
                .Inc<AbilityInHandComponent>()
                .Inc<AnimationDataLinkComponent>()
                .Inc<AbilityActiveAnimationComponent>()
                .Inc<LinkToAnimationComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var activeAnimationComponent = ref _animationAspect.ActiveAnimation.Get(entity);
                ref var animationComponent = ref _animationAspect.AnimationLink.Get(entity);
                activeAnimationComponent.Value = animationComponent.Value;
            }
        }
    }
}