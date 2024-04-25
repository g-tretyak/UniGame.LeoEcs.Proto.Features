namespace Game.Code.Ai.ActivateAbility
{
    using System;
    using Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using unigame.ecs.proto.Ability.SubFeatures.Target.Tools;
    using unigame.ecs.proto.Ability.Tools;
    using unigame.ecs.proto.AI.Abstract;
    using unigame.ecs.proto.AI.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Show and Hides HealthBars based on UnderTheTargetComponent 
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    [Serializable]
    public sealed class ActivateAbilityActionSystem : IAiActionSystem,IProtoInitSystem
    {
        private AbilityTools _abilityTools;
        private AbilityTargetTools _targetTools;
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<ActivateAbilityActionComponent> _activateAbilityPool;
        private ProtoPool<OwnerComponent> _ownerPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _abilityTools = _world.GetGlobal<AbilityTools>();
            _targetTools = _world.GetGlobal<AbilityTargetTools>();
            
            _filter = _world
                .Filter<AiAgentComponent>()
                .Inc<ActivateAbilityActionComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var activateAbilityComponent = ref _activateAbilityPool.Get(entity);
                ref var target = ref activateAbilityComponent.Target;
                var slot = activateAbilityComponent.AbilityCellId;

                if(!activateAbilityComponent.Ability.Unpack(_world,out var abilityEntity))
                    continue;
                
                var cooldownPassed = _abilityTools.IsAbilityCooldownPassed(abilityEntity);
                //проверяем кулдаун абилки, если он не прошел - игнорируем
                if (!cooldownPassed) continue;
                
                _targetTools.ActivateAbilityForTarget(entity,target, slot);
            }
        }
    }
}