namespace unigame.ecs.proto.Ability.SubFeatures.CriticalAnimations.Systems
{
    using System;
    using Common.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// increase counter on each animation
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class UpdateAnimationsVariantCounterSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;

        private ProtoPool<AbilityAnimationVariantCounterComponent> _counterPool;
        private ProtoPool<AbilityAnimationVariantsComponent> _variantsPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<AbilityStartUsingSelfEvent>()
                .Inc<OwnerComponent>()
                .Inc<AbilityAnimationVariantCounterComponent>()
                .Inc<AbilityAnimationVariantsComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var abilityEntity in _filter)
            {
                ref var counterComponent = ref _counterPool.Get(abilityEntity);
                ref var variantsComponent = ref _variantsPool.Get(abilityEntity);

                var animationsCount = variantsComponent.Variants.Count;
                if(animationsCount == 0)
                    continue;
                
                var counter = counterComponent.Value;
                counter++;
                counter = counter % animationsCount;
                counterComponent.Value = counter;
            }
        }
    }
}