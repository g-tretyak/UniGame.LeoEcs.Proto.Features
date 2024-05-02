namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Systems
{
    using System;
    using Aspects;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using TargetSelection;
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
    public sealed class ProcessTargetsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private TargetAbilityAspect _targetAspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<AbilityTargetsComponent>()
                .Inc<OwnerComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var owner = ref _targetAspect.Owner.Get(entity);
                ref var targets = ref _targetAspect.AbilityTargets.Get(entity);
                
                var packedSource = owner.Value;
                var amount = targets.Count;
                
                for (var i = 0; i < amount; i++)
                {
                    ref var packedEntity = ref targets.Entities[i];
                    if(!packedEntity.Unpack(_world, out var targetEntity))
                        continue;
                    
                    ref var underTarget = ref _targetAspect.UnderTheTarget.GetOrAddComponent(targetEntity);
                    var addTarget = true;
                    var count = underTarget.Count;
                    
                    if(count >= TargetSelectionData.MaxTargets) continue;
                    
                    for (var j = 0; j < count; j++)
                    {
                        ref var targetSource = ref underTarget.Entities[j];
                        if (!targetSource.EqualsTo(packedSource)) continue;
                        addTarget = false;
                        break;
                    }
                    
                    if(!addTarget) continue;
                    
                    underTarget.Entities[count] = packedSource;
                    underTarget.Count++;
                }
            }
        }
    }
}