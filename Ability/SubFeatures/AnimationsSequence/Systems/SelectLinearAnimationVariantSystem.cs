namespace unigame.ecs.proto.Ability.SubFeatures.CriticalAnimations.Systems
{
    using System;
    using Ability.Components;
    using AbilityAnimation.Components;
    using Common.Components;
    using Components;
    using Core.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    ///  select linear animation variant
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SelectLinearAnimationVariantSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        
        private ProtoPool<AbilityAnimationOptionComponent> _optionPool;
        private ProtoPool<OwnerComponent> _ownerPool;
        private ProtoPool<AbilityAnimationVariantsComponent> _variantsPool;
        private ProtoPool<AbilityAnimationVariantCounterComponent> _counterPool;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world
                .Filter<AbilityStartUsingSelfEvent>()
                .Inc<OwnerComponent>()
                .Inc<AbilityInHandComponent>()
                .Inc<AbilityAnimationVariantCounterComponent>()
                .Inc<LinearAbilityAnimationSelectionComponent>()
                .Inc<AbilityAnimationVariantsComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var ownerComponent = ref _ownerPool.Get(entity);
                if(!ownerComponent.Value.Unpack(_world,out var owner))
                    continue;

                ref var counterComponent = ref _counterPool.Get(entity);
                ref var variantsComponent = ref _variantsPool.Get(entity);

                var order = counterComponent.Value;
                if(variantsComponent.Variants.Count <= order)
                    continue;
                
                var variant = variantsComponent.Variants[order];
                if(!variant.Unpack(_world,out var variantEntity))
                    continue;
                
                ref var optionComponent = ref _optionPool.GetOrAddComponent(variantEntity);
            }
        }
    }
}