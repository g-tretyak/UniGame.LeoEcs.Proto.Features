namespace unigame.ecs.proto.Ability.SubFeatures.AbilityAnimation.Systems
{
    using System;
    using Aspects;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using unigame.ecs.proto.Ability.Common.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Reset all animation options on launch ability
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class AbilityResetAnimationOptionsSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private EcsFilter _abilityOptionsFilter;
        
        private AbilityAnimationOptionAspect _optionAspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<AbilityStartUsingSelfEvent>()
                .Inc<OwnerComponent>()
                .Inc<AbilityInHandComponent>()
                .End();

            _abilityOptionsFilter = _world
                .Filter<AbilityAnimationOptionComponent>()
                .Inc<OwnerComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                foreach (var optionEntity in _abilityOptionsFilter)
                {
                    ref var optionOwnerComponent = ref _optionAspect.Owner.Get(optionEntity);
                    
                    if(!optionOwnerComponent.Value.Unpack(_world,out var optionOwner))
                        continue;
                    
                    if(!optionOwner.Equals(entity)) continue;
                    
                    _optionAspect.Option.Del(optionEntity);
                }
            }
        }
    }
}