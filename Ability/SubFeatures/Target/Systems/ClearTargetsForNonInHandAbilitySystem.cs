namespace unigame.ecs.proto.Ability.SubFeatures.Target.Systems
{
    using System;
    using Aspects;
    using Common.Components;
    using Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ClearTargetsForNonInHandAbilitySystem : IProtoRunSystem,IProtoInitSystem
    {
        
        private EcsFilter _filter;
        private ProtoWorld _world;

        private TargetAbilityAspect _targetAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<AbilityTargetsComponent>()
                .Exc<AbilityInHandComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {   
                ref var targets = ref _targetAspect.AbilityTargets.Get(entity);
                targets.Count = 0;
                targets.PreviousCount = 0;
            }
        }
    }
}