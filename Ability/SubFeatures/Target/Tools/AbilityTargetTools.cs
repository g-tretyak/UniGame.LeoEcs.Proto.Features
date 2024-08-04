namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Tools
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Ability.Aspects;
    using Aspects;
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
    [ECSDI]
	public class AbilityTargetTools : IProtoInitSystem
	{
        private ProtoPackedEntity[] _buffer = new ProtoPackedEntity[TargetSelectionData.MaxTargets];
        private ProtoWorld _world;

        private AbilityAspect _abilityAspect;
        private TargetAbilityAspect _targetAbilityAspect;
        private AbilityOwnerAspect _ownerAspect;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
        }
        
#if ENABLE_IL2CPP
	    [Il2CppSetOption(Option.NullChecks, false)]
	    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ActivateAbilityForTarget(ProtoEntity entity, int targetEntity, int slot)
        {
            var packedEntity = _world.PackEntity(targetEntity);
            ActivateAbilityForTarget( entity, packedEntity, slot);
        }
        
#if ENABLE_IL2CPP
	    [Il2CppSetOption(Option.NullChecks, false)]
	    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearAbilityTargets(ProtoEntity entity, int slot)
        {
            var abilityEntity = _abilityAspect.GetAbilityBySlot(entity, slot);
            if(!abilityEntity.Unpack(_world,out var ability)) return;
            ClearAbilityTargets(ability);
        }

#if ENABLE_IL2CPP
	    [Il2CppSetOption(Option.NullChecks, false)]
	    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearAbilityTargets(ProtoEntity abilityEntity)
        {
            //set ability target
            ref var targetsComponent = ref _targetAbilityAspect
                .AbilityTargets
                .GetOrAddComponent(abilityEntity);
            
            targetsComponent.SetEmpty();
        }

#if ENABLE_IL2CPP
	    [Il2CppSetOption(Option.NullChecks, false)]
	    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        public void SetAbilityTarget(ProtoEntity entity, ProtoPackedEntity targetEntity, int slot)
        {
            var abilityEntity = _abilityAspect.GetAbilityBySlot(entity, slot);
            if(!abilityEntity.Unpack(_world,out var ability)) return;

            //set ability target
            ref var targetsComponent = ref _targetAbilityAspect
                .AbilityTargets
                .GetOrAddComponent(ability);
            
            targetsComponent.SetEntity(targetEntity);
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        public void ActivateAbilityForTarget(ProtoEntity entity, ProtoPackedEntity targetEntity, int slot)
        {
            var abilityEntity = _abilityAspect.GetAbilityBySlot(entity, slot);
            if(!abilityEntity.Unpack(_world,out var ability)) return;
            ActivateAbilityWithTarget(entity, ability,ref targetEntity);
        }
        
#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ActivateAbilityWithTarget(ProtoEntity entity,ProtoEntity abilityEntity,ref ProtoPackedEntity targetEntity)
        {
            //set ability target
            ref var targetsComponent = ref _targetAbilityAspect
                .AbilityTargets
                .GetOrAddComponent(abilityEntity);
            
            targetsComponent.SetEntity(targetEntity);

            //activate ability
            ActivateAbility( entity, abilityEntity);
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ActivateAbilityWithTargets(ProtoWorld world, ProtoEntity entity,
            ProtoEntity abilityEntity,ProtoPackedEntity[] targets,int count)
        {
            for (var i = 0; i < count; i++)
                _buffer[i] = targets[i];
            
            //set ability target
            ref var targetsComponent = ref _targetAbilityAspect
                .AbilityTargets
                .GetOrAddComponent(abilityEntity);
            
            targetsComponent.SetEntities(_buffer, count);

            //activate ability
            ActivateAbility( entity, abilityEntity);
        }
        

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ActivateAbilityWithTargets(ProtoEntity entity, ProtoEntity abilityEntity,IReadOnlyList<ProtoPackedEntity> targets)
        {
            var count = targets.Count;
            for (var i = 0; i < targets.Count; i++)
                _buffer[i] = targets[i];
            
            //set ability target
            ref var targetsComponent =  ref _targetAbilityAspect
                .AbilityTargets
                .GetOrAddComponent(abilityEntity);
            
            targetsComponent.SetEntities(_buffer, count);

            //activate ability
            ActivateAbility( entity, abilityEntity);
        }
        
#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        public void ActivateAbility(ProtoEntity ownerEntity, ProtoEntity abilityEntity)
        {
            var packedAbilityEntity = _world.PackEntity(abilityEntity);
            ref var setInHand = ref _ownerAspect.SetInHandAbility.GetOrAddComponent(ownerEntity);
            ref var abilityUseRequest = ref _ownerAspect.ApplyAbility.GetOrAddComponent(ownerEntity);
            
            setInHand.Value = packedAbilityEntity;
            abilityUseRequest.Value = packedAbilityEntity;
        }

    }
}