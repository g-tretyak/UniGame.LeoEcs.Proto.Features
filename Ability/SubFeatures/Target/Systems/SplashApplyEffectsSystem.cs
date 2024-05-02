namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Systems
{
    using Aspects;
    using Common.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Proto.Effects;
    using TargetSelection;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif

    /// <summary>
    /// Apply effects on targets
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    public sealed class SplashApplyEffectsSystem : IProtoRunSystem, IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private TargetAbilityAspect _aspect;
        
        private ProtoEntity[] _targets = new ProtoEntity[TargetSelectionData.MaxTargets];
        private ProtoEntity[] _zoneTargets = new ProtoEntity[TargetSelectionData.MaxTargets];

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<SplashEffectSourceComponent>()
                .Inc<AbilityStartUsingSelfEvent>()
                .Inc<OwnerComponent>()
                .Inc<AbilityTargetsComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var owner = ref _aspect.Owner.Get(entity);
                ref var abilityTargets = ref _aspect.AbilityTargets.Get(entity);
                ref var splashEffectComponent = ref _aspect.SplashApplyEffects.Get(entity);

                if (!owner.Value.Unpack(_world, out var ownerEntity)) continue;

                var amount = _world.UnpackAll(abilityTargets.Entities,_targets,abilityTargets.Count);
                if (amount <= 0) continue;
                
                ref var soloTargetComponent = ref _aspect.SoloTarget.Get(entity);
                var soloTarget = soloTargetComponent.Value;
                if (!soloTarget.Unpack(_world, out var soloTargetEntity))
                    continue;
                
                splashEffectComponent.MainTargetEffects.CreateRequests(_world, owner.Value, soloTarget);
                
                // TODO: remove splash characteristic from this system
                if (!_aspect.SplashCharacteristics.Has(ownerEntity)) continue;
                ref var splashCharacteristics = ref _aspect.SplashCharacteristics.Get(ownerEntity);
                if (splashCharacteristics.Value == 0) continue;
                
                var targetsInZone = splashEffectComponent
                    .ZoneTargetsDetector
                    .GetTargetsInZone(_world,_zoneTargets, ownerEntity, _targets,amount);

                for (int i = 0; i < targetsInZone; i++)
                {
                    var target = _zoneTargets[i];
                    
                    if (soloTargetEntity.Equals(target)) continue;
                    
                    splashEffectComponent.OtherTargetsEffects
                        .CreateRequests(_world, owner.Value, _world.PackEntity(target));
                }

            }
        }
    }
}
