namespace UniGame.Ecs.Proto.Ability.Tools
{
    using System;
    using System.Runtime.CompilerServices;
    using AbilityInventory.Components;
    using Animations.Components;
    using Animations.Components.Requests;
    using Aspects;
    using Characteristics.Cooldown.Components;
    using Characteristics.Duration.Components;
    using Characteristics.Radius.Component;
    using Common.Components;
    using Components;
    using Components.Requests;
    using Core.Components;
    using Cysharp.Threading.Tasks;
    using Game.Code.Animations;
    using Game.Code.Animations.EffectMilestones;
    using Game.Code.Configuration.Runtime.Ability;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Game.Code.Services.AbilityLoadout.Data;
    using Game.Ecs.Core.Components;
    using Game.Ecs.Time.Service;
    using GameLayers.Category.Components;
    using GameLayers.Relationship.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using SubFeatures.AbilityAnimation.Components;
    using UniGame.AddressableTools.Runtime;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Timer.Components;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    [Serializable]
    public class AbilityTools : IProtoInitSystem
    {
        private ProtoEntity _invalidEntity = ProtoEntity.FromIdx(-1);
        private EcsFilter _abilityFilter;
        private EcsFilter _abilityInUseFilter;
        private EcsFilter _existsAbilityFilter;
        private AbilityOwnerAspect _abilityOwnerAspect;
        private AbilityAspect _abilityAspect;
        private ProtoEntity _invalidAbility = ProtoEntity.FromIdx(-1);

        private ProtoWorld _world;

        public ProtoPool<RadiusComponent> _radius;
        private ProtoPool<AbilityIdComponent> _abilityIdPool;
        private ProtoPool<AbilityUsingComponent> _abilityInUsePool;
        private ProtoPool<CategoryIdComponent> _category;
        private ProtoPool<RelationshipIdComponent> _relationship;
        private ProtoPool<EquipAbilityIdSelfRequest> _eqiupAbilityPool;
        private ProtoPool<EquipAbilityReferenceSelfRequest> _eqiupAbilityReferencePool;
        private ProtoPool<AbilityIdComponent> _abiilityIdPool;
        private ProtoPool<AbilityMapComponent> _abilityMapPool;
        private ProtoPool<AbilityInHandLinkComponent> _abilityInHandLinkPool;
        private ProtoPool<AbilityInHandComponent> _abilityInHandPool;
        private ProtoPool<OwnerComponent> _ownerPool;
        private ProtoPool<AbilityVisualComponent> _visual;
        private ProtoPool<IconComponent> _icon;
        private ProtoPool<DescriptionComponent> _description;
        private ProtoPool<NameComponent> _name;
        private ProtoPool<CooldownStateComponent> _cooldownState;
        private ProtoPool<CooldownComponent> _cooldown;
        private ProtoPool<BaseCooldownComponent> _baseCooldown;
        private ProtoPool<DurationComponent> _duration;
        private ProtoPool<AbilityActiveAnimationComponent> _animation;
        private ProtoPool<UserInputAbilityComponent> _input;
        private ProtoPool<AbilityBlockedComponent> _blocked;
        private ProtoPool<AbilitySlotComponent> _slot;
        private ProtoPool<AbilityIdComponent> _id;
        private ProtoPool<OwnerLinkComponent> _ownerLink;
        private ProtoPool<CompleteAbilitySelfRequest> _completeAbilityPool;
        
        public void Init(IProtoSystems systems)
        {
            var world = systems.GetWorld();
            _world = world;
            _abilityFilter = world
                .Filter<AbilityIdComponent>()
                .Inc<ActiveAbilityComponent>()
                .Inc<OwnerComponent>()
                .End();

            _abilityInUseFilter = world
                .Filter<AbilityIdComponent>()
                .Inc<AbilityUsingComponent>()
                .Inc<ActiveAbilityComponent>()
                .Inc<OwnerComponent>()
                .End();

            _existsAbilityFilter = _world
                .Filter<AbilityIdComponent>()
                .Inc<OwnerLinkComponent>()
                .Inc<ActiveAbilityComponent>()
                .End();
        }

        public void BuildAbility(
            ProtoEntity abilityEntity,
            ref ProtoPackedEntity ownerEntity,
            AbilityConfiguration abilityConfiguration,
            ref AbilityBuildData buildData)
        {
            var packedAbility = _world.PackEntity(abilityEntity);
            ref var slotComponent = ref _slot.GetOrAddComponent(abilityEntity);
            ref var abilityIdComponent = ref _id.GetOrAddComponent(abilityEntity);
            ref var ownerComponent = ref _ownerPool.GetOrAddComponent(abilityEntity);
            ref var ownerLinkComponent = ref _ownerLink.GetOrAddComponent(abilityEntity);
            
            ownerLinkComponent.Value = ownerEntity;
            ownerComponent.Value = ownerEntity;
            slotComponent.SlotType = buildData.Slot;
            abilityIdComponent.AbilityId = buildData.AbilityId;
            
            if (buildData.IsUserInput) _input.GetOrAddComponent(abilityEntity);
            if (buildData.IsBlocked) _blocked.GetOrAddComponent(abilityEntity);
                
            //add visual
            if (_visual.Has(abilityEntity))
            {
                ref var visualComponent = ref _visual.Get(abilityEntity);
                ComposeAbilityVisualDescription(ref visualComponent,abilityEntity);
            }
                
            ComposeAbilitySpecification(abilityConfiguration.specification, abilityEntity);
            
            var abilityLink = abilityConfiguration.animationLink.reference;

            if (abilityConfiguration.useAnimation)
            {
#if UNITY_EDITOR
                if (abilityLink == null || !abilityLink.RuntimeKeyIsValid())
                {
                    Debug.LogError($"Missing ability animation link FOR {abilityConfiguration.name}");
                }
#endif
                ComposeAbilityAnimationAsync(_world, ownerEntity,packedAbility,abilityLink).Forget();
            }
            else
            {
                ref var durationComponent = ref _duration.GetOrAddComponent(abilityEntity);
                durationComponent.Value = abilityConfiguration.duration;
                ref var milestonesComponent = ref _world.GetOrAddComponent<AbilityEffectMilestonesComponent>(abilityEntity);
                milestonesComponent.Milestones = new[]
                {
                    new EffectMilestone { Time = 0f }
                };
            }

            foreach (var abilityBehaviour in abilityConfiguration.abilityBehaviours)
                abilityBehaviour.Compose(_world, abilityEntity, buildData.IsDefault);
        }
        
#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetAbilityById(ref ProtoPackedEntity ownerEntity, AbilityId abilityId, out ProtoEntity resultAbility)
        {
            foreach (var abilityEntity in _abilityFilter)
            {
                ref var ownerComponent = ref _ownerPool.Get(abilityEntity);
                if (!ownerEntity.EqualsTo(ownerComponent.Value)) continue;

                ref var abilityIdComponent = ref _abiilityIdPool.Get(abilityEntity);
                if (abilityId != abilityIdComponent.AbilityId) continue;

                resultAbility = abilityEntity;
                return true;
            }

            resultAbility = _invalidEntity;
            return false;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetExistsAbility(int abilityId, ref ProtoPackedEntity targetEntity)
        {
            foreach (var abilityEntity in _existsAbilityFilter)
            {
                ref var abilityIdComponent = ref _abilityIdPool.Get(abilityEntity);
                ref var ownerComponent = ref _ownerPool.Get(abilityEntity);

                if (abilityIdComponent.AbilityId != abilityId ||
                    !ownerComponent.Value.Equals(targetEntity)) continue;

                return  (int)abilityEntity;
            }

            return -1;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetActivatedAbility(ProtoEntity ownerEntity)
        {
	        ref var abilityMap = ref _abilityMapPool.Get(ownerEntity);
	        foreach (var abilityMapAbilityEntity in abilityMap.AbilityEntities)
	        { 
		        if (!abilityMapAbilityEntity.Unpack(_world, out var abilityEntity))
			        continue;
		        if (!_abilityInUsePool.Has(abilityEntity))
			        continue;
		        if (_completeAbilityPool.Has(abilityEntity))
			        continue;
		        return (int)abilityEntity;
	        }
	        return -1;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ChangeInHandAbility(ProtoWorld world, ProtoEntity entity, ProtoEntity newAbility)
        {
            ref var targetInHandComponent = ref _abilityInHandLinkPool.Get(entity);
            var abilityEntity = targetInHandComponent.AbilityEntity;

            if (abilityEntity.Unpack(world, out var previousAbility))
            {
                if (previousAbility.Equals(newAbility))
                    return;

                _abilityInHandPool.TryRemove(previousAbility);
            }

            if (!_abilityInHandPool.Has(newAbility))
                _abilityInHandPool.Add(newAbility);

            abilityEntity = world.PackEntity(newAbility);
            targetInHandComponent.AbilityEntity = abilityEntity;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsAbilityCooldownPassed(ProtoEntity abilityEntity)
        {
            //проверяем кулдаун абилки, если он не прошел - игнорируем
            if (!_world.EntityHasAll<CooldownComponent, CooldownStateComponent>(abilityEntity))
                return true;

            ref var coolDownComponent = ref _world.GetComponent<CooldownComponent>(abilityEntity);
            ref var coolDownStateComponent = ref _world.GetComponent<CooldownStateComponent>(abilityEntity);
            var timePassed = (GameTime.Time - coolDownStateComponent.LastTime) - coolDownComponent.Value;
            return timePassed > 0;
        }


#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProtoEntity GetAbilityBySlot(ProtoEntity ownerEntity, int slotId)
        {
            ref var abilityMapComponent = ref _abilityOwnerAspect.AbilityMap.Get(ownerEntity);
            var abilityMap = abilityMapComponent.AbilityEntities;

            if (slotId < 0 || slotId >= abilityMap.Count)
                return _invalidAbility;

            var packedAbility = abilityMap[slotId];
            return packedAbility.Unpack(_world, out var abilityEntity)
                ? abilityEntity
                : _invalidAbility;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetAbilitySlot(ProtoWorld world, ProtoEntity ownerEntity, ProtoEntity abilityEntity)
        {
            ref var abilityMap = ref _abilityMapPool.Get(ownerEntity);
            var counter = 0;

            foreach (var abilityPacked in abilityMap.AbilityEntities)
            {
                if (!abilityPacked.Unpack(world, out var targetAbility)) continue;
                if (abilityEntity.Equals(targetAbility)) return counter;
                counter++;
            }

            return AbilitySlotId.EmptyAbilitySlot;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsAnyAbilityInUse(ProtoEntity entity)
        {
            if (!_abilityMapPool.Has(entity)) return false;
            
            ref var abilityMapComponent = ref _abilityMapPool.Get(entity);
            var abilityMap = abilityMapComponent.AbilityEntities;
            
            for (var i = 0; i < abilityMap.Count; i++)
            {
                var packedAbility = abilityMap[i];
                if(!packedAbility.Unpack(_world,out var abilityEntity))
                    continue;

                if (_abilityInUsePool.Has(abilityEntity))
                    return true;
            }
            
            return false;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetNonDefaultAbilityInUse(ProtoEntity entity)
        {
            if(!_abilityOwnerAspect.AbilityInProcessing.Has(entity))
                return -1;
            
            ref var processingComponent = ref _abilityOwnerAspect
                .AbilityInProcessing.Get(entity);

            if (processingComponent.IsDefault) return -1;
            
            if(!processingComponent.Ability.Unpack(_world,out var abilityEntity))
                return -1;
            
            return (int)abilityEntity;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProtoEntity EquipAbilityById(ref ProtoPackedEntity owner, ref AbilityId abilityId)
        {
            return EquipAbilityById(ref owner, abilityId, AbilitySlotId.EmptyAbilitySlot);
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProtoEntity EquipAbilityById(ref ProtoPackedEntity owner, AbilityId abilityId,
            AbilitySlotId slot, bool isDefault = false)
        {
            var activeAbility = GetActiveAbility(ref owner, ref abilityId);
            if (activeAbility > 0) return (ProtoEntity)activeAbility;

            var requestEntity = _world.NewEntity();
            ref var request = ref _eqiupAbilityPool.Add(requestEntity);
            request.AbilityId = abilityId;
            request.AbilitySlot = slot;
            request.Owner = owner;
            request.IsDefault = isDefault;
            request.IsUserInput = false;

            return requestEntity;
        }
        
        
#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProtoEntity EquipAbilityByReference(ref ProtoPackedEntity owner, 
            AbilityConfiguration configuration,
            AbilitySlotId slot, bool isDefault = false)
        {
            var requestEntity = _world.NewEntity();
            ref var request = ref _eqiupAbilityReferencePool.Add(requestEntity);
            request.AbilitySlot = slot;
            request.Owner = owner;
            request.IsDefault = isDefault;
            request.IsUserInput = false;
            request.Reference = configuration;

            return requestEntity;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetActiveAbility(ref ProtoPackedEntity owner, ref AbilityId abilityId)
        {
            foreach (var abilityEntity in _abilityFilter)
            {
                ref var ownerComponent = ref _ownerPool.Get(abilityEntity);
                if (!owner.Equals(ownerComponent.Value)) continue;

                ref var abilityIdComponent = ref _abiilityIdPool.Get(abilityEntity);
                if (abilityId != abilityIdComponent.AbilityId) continue;

                return (int)abilityEntity;
            }

            return -1;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int IsActiveAbilityEntity(ref ProtoPackedEntity owner, ProtoEntity targetAbility)
        {
            foreach (var abilityEntity in _abilityFilter)
            {
                ref var ownerComponent = ref _ownerPool.Get(abilityEntity);
                if (!owner.Equals(ownerComponent.Value)) continue;

                if (!targetAbility.Equals(abilityEntity)) continue;
                return (int)abilityEntity;
            }

            return -1;
        }
        
#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComposeAbilityVisualDescription(ref AbilityVisualComponent visualDescription, ProtoEntity abilityEntity)
        {
            ref var visualComponent = ref _visual.GetOrAddComponent(abilityEntity);
            visualComponent.Description = visualDescription.Description;
            visualComponent.Icon = visualDescription.Icon;
            visualComponent.Name = visualDescription.Name;

            ref var iconComponent = ref _icon.GetOrAddComponent(abilityEntity);
            ref var descriptionComponent = ref _description.GetOrAddComponent(abilityEntity);
            ref var nameComponent = ref _name.GetOrAddComponent(abilityEntity);
            
            nameComponent.Value = visualDescription.Name;
            descriptionComponent.Description = visualDescription.Description;
            iconComponent.Value = visualDescription.Icon;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComposeAbilitySpecification(AbilitySpecification specification, ProtoEntity abilityEntity)
        {
            ref var radiusComponent = ref _radius.GetOrAddComponent(abilityEntity);
            ref var category = ref _category.GetOrAddComponent(abilityEntity);
            ref var relationship = ref _relationship.GetOrAddComponent(abilityEntity);
            ref var abilityCooldownComponent = ref _cooldownState.GetOrAddComponent(abilityEntity);
            ref var cooldownComponent = ref _cooldown.GetOrAddComponent(abilityEntity);
            ref var baseCooldown = ref _baseCooldown.GetOrAddComponent(abilityEntity);
            
            baseCooldown.Value = specification.Cooldown;
            cooldownComponent.Value = specification.Cooldown;
            abilityCooldownComponent.LastTime = GameTime.Time - specification.Cooldown;
            radiusComponent.Value = specification.Radius;
            relationship.Value = specification.RelationshipId;
            category.Value = specification.CategoryId;
        }
        

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public async UniTask ComposeAbilityAnimationAsync(ProtoWorld world, 
            ProtoPackedEntity animationTarget,
            ProtoPackedEntity abilityEntity,
            AssetReferenceT<AnimationLink> animationLinkReference)
        {
            var lifetime = world.GetWorldLifeTime();
            var animationLink = await animationLinkReference.LoadAssetTaskAsync(lifetime);
            ComposeAbilityAnimation(world,ref animationTarget,ref abilityEntity, animationLink);
        }
        
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComposeAbilityAnimation(ProtoWorld world, 
            ref ProtoPackedEntity animationTarget,
            ref ProtoPackedEntity ability,
            AnimationLink animationLink)
        {
            if(!ability.Unpack(world,out var abilityEntity)) return;
            
            ref var activeAnimationComponent = ref _animation.GetOrAddComponent(abilityEntity);
            ref var durationComponent = ref _duration.GetOrAddComponent(abilityEntity);

            if (animationLink == null)
            {
                ComposeEffectMilestones(world, null, 0.0f, abilityEntity);
                return;
            }
            
            var animation = animationLink.animation;
            var duration = animationLink.duration;
            duration = duration <= 0 && animation!=null ? (float)animation.duration : duration;
                
            durationComponent.Value = duration;
                
            ref var animationComponent = ref world.GetOrAddComponent<AnimationDataLinkComponent>(abilityEntity);
            ref var wrapModeComponent = ref world.GetOrAddComponent<AnimationWrapModeComponent>(abilityEntity);
            ref var linkToAnimationComponent = ref world.GetOrAddComponent<LinkToAnimationComponent>(abilityEntity);

            var animationEntity = _world.NewEntity();
            ref var createAnimationRequest = ref _world
                .GetOrAddComponent<CreateAnimationLinkSelfRequest>(animationEntity);
                
            var packedAnimation = world.PackEntity(animationEntity);
                
            createAnimationRequest.Data = animationLink;
            createAnimationRequest.Owner = world.PackEntity(abilityEntity);
            createAnimationRequest.Target = animationTarget;
                
            linkToAnimationComponent.Value = packedAnimation;
            activeAnimationComponent.Value = packedAnimation;
                
            animationComponent.AnimationLink = animationLink;
            wrapModeComponent.Value = animationLink.wrapMode;
                
            ComposeEffectMilestones(world, animationLink.milestones, animationLink.Duration, abilityEntity);
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComposeEffectMilestones(ProtoWorld world, 
            EffectMilestonesData milestonesInfo, 
            float duration,
            ProtoEntity abilityEntity)
        {
            if (milestonesInfo == null) return;
            
            ref var effectMilestones = ref world.GetOrAddComponent<AbilityEffectMilestonesComponent>(abilityEntity);

            var effects = milestonesInfo.effectMilestones;
            if (effects.Count == 0)
            {
                effectMilestones.Milestones = new[]
                {
                    new EffectMilestone { Time = duration }
                };

                return;
            }

            effectMilestones.Milestones = new EffectMilestone[effects.Count];
            
            for (var i = 0; i < effectMilestones.Milestones.Length; i++)
            {
                var sourceMilestone = effects[i];
                var cloneMilestone = sourceMilestone.Clone();
                effectMilestones.Milestones[i] = cloneMilestone;
            }
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ActivateAbility(ProtoWorld world, ProtoEntity entity, ProtoEntity abilityEntity)
        {
            var packedAbilityEntity = world.PackEntity(abilityEntity);
            ref var setInHand = ref world.GetOrAddComponent<SetInHandAbilitySelfRequest>(entity);
            setInHand.Value = packedAbilityEntity;

            ref var abilityUseRequest = ref world.GetOrAddComponent<ApplyAbilitySelfRequest>(entity);
            abilityUseRequest.Value = packedAbilityEntity;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ActivateAbility(ProtoWorld world, ProtoEntity abilityEntity)
        {
            if (!world.HasComponent<OwnerComponent>(abilityEntity)) return;

            ref var ownerComponent = ref world.GetComponent<OwnerComponent>(abilityEntity);
            if (!ownerComponent.Value.Unpack(world, out var ownerEntity)) return;

            ActivateAbility(world, ownerEntity, abilityEntity);
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ActivateAbilitySlot(ProtoWorld world, int entity, int slot)
        {
            ref var setInHand = ref world.GetOrAddComponent<SetInHandAbilityBySlotSelfRequest>(entity);
            setInHand.AbilityCellId = slot;

            var abilityInputPool = world.GetPool<ApplyAbilityBySlotSelfRequest>();
            ref var abilityUseRequest = ref abilityInputPool.GetOrAddComponent(entity);
            abilityUseRequest.AbilitySlot = slot;
        }
        
#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ActivateAbilityId(ref ProtoPackedEntity entity, int abilityId)
        {
            var requestEntity = _world.NewEntity();
            ref var activateRequest = ref _world.GetOrAddComponent<ActivateAbilityByIdRequest>(requestEntity);
            activateRequest.AbilityId = abilityId;
            activateRequest.Target = entity;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        public bool TryGetInHandAbility(ProtoWorld world, ProtoEntity entity, out ProtoEntity abilityEntity)
        {
            abilityEntity = _invalidEntity;
            var abilityInHandPool = world.GetPool<AbilityInHandLinkComponent>();
            if (!abilityInHandPool.Has(entity))
                return false;

            ref var inHandAbility = ref abilityInHandPool.Get(entity);
            if (!inHandAbility.AbilityEntity.Unpack(world, out var ability))
                return false;

            abilityEntity = ability;
            return true;
        }

#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        public bool TryGetDefaultAbility(ProtoWorld world, ProtoEntity entity, out ProtoEntity abilityEntity)
        {
            abilityEntity = _invalidEntity;
            var abilityMapPool = world.GetPool<AbilityMapComponent>();
            var defaultPool = world.GetPool<DefaultAbilityComponent>();

            if (!abilityMapPool.Has(entity)) return false;

            ref var map = ref abilityMapPool.Get(entity);

            foreach (var mapAbilityEntity in map.AbilityEntities)
            {
                if (!mapAbilityEntity.Unpack(world, out var abilityEntityValue)) continue;
                if (!defaultPool.Has(abilityEntityValue)) continue;
                abilityEntity = abilityEntityValue;
                return true;
            }

            return false;
        }

#if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProtoEntity TryGetAbility(ProtoEntity entity, int slot)
        {
            var abilityEntity = ProtoEntity.FromIdx(-1);

            if (!_abilityOwnerAspect.AbilityMap.Has(entity)) return abilityEntity;

            ref var map = ref _abilityOwnerAspect.AbilityMap.Get(entity);
            var count = map.AbilityEntities.Count;
            var isInBounds = slot >= 0 && count > slot;
            if(!isInBounds) return abilityEntity;
            
            return map.AbilityEntities[slot].Unpack(_world, out var ability) 
                ? ability : abilityEntity;
        }

    }
}