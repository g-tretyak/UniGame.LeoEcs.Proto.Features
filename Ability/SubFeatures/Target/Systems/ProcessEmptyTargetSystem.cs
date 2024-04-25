namespace unigame.ecs.proto.Ability.SubFeatures.Target.Systems
{
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using TargetSelection;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Add an empty target to an ability
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    public class ProcessEmptyTargetSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filterAbilityTarget;
        private EcsFilter _filterEmptyTarget;

        private TargetAbilityAspect _targetAspect;
        
        private ProtoPool<AbilityTargetsComponent> _abilityTargetPool;
        private ProtoPool<SoloTargetComponent> _soleTargetPool;
        private ProtoPool<EmptyTargetComponent> _emptyTargetPool;
        
        private int _emptyEntity;
        
        private ProtoPackedEntity[] _targets = new ProtoPackedEntity[TargetSelectionData.MaxTargets];

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filterEmptyTarget = _world
                .Filter<EmptyTargetComponent>()
                .End();

            _filterAbilityTarget = _world
                .Filter<AbilityTargetsComponent>()
                .Inc<NonTargetAbilityComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var abilityTargetsEntity in _filterAbilityTarget)
            {
                ref var abilityTargetsComponent = ref _targetAspect.AbilityTargets.Get(abilityTargetsEntity);
                if(abilityTargetsComponent.Count > 0) continue;
                
                ref var soloTargetComponent = ref _targetAspect.SoloTarget.Get(abilityTargetsEntity);
                var counter = 0;

                foreach (var emptyTargetEntity in _filterEmptyTarget)
                {
                    if (counter >= TargetSelectionData.MaxTargets) break;
                    
                    var emptyTargetPack = _world.PackEntity(emptyTargetEntity);
                    _targets[counter] = emptyTargetPack;
                    
                    soloTargetComponent.Value = emptyTargetPack;
                    counter++;
                }

                abilityTargetsComponent.SetEntities(_targets,counter);
            }
        }
    }

}