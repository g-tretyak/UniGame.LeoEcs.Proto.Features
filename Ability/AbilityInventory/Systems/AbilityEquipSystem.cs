namespace UniGame.Ecs.Proto.AbilityInventory.Systems
{
	using System;
	using System.Collections.Generic;
	using Ability.Aspects;
	using Ability.Tools;
	using Aspects;
	using Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using Leopotam.EcsProto.QoL;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;

	/// <summary>
	/// Equip ability to slot
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class AbilityEquipSystem : IProtoInitSystem, IProtoRunSystem
	{
		private AbilityTools _abilityTools;
		private AbilityInventoryAspect _inventoryAspect;
		private AbilityAspect _abilityAspect;
		private AbilityOwnerAspect _abilityOwnerAspect;
		
		private ProtoWorld _world;
		private EcsFilter _filter;
		
		private List<ProtoEntity> _removedEntities = new List<ProtoEntity>();

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_abilityTools = _world.GetGlobal<AbilityTools>();
			
			_filter = _world
				.Filter<AbilityInventoryCompleteComponent>()
				.Inc<EquipAbilitySelfRequest>()
				.Inc<AbilityBuildingComponent>()
				.End();
		}

		public void Run()
		{
			_removedEntities.Clear();
			
			foreach (var abilityEntity in _filter)
			{
				ref var requestComponent = ref _inventoryAspect.Equip.Get(abilityEntity);
				ref var ownerComponent = ref _inventoryAspect.Owner.Get(abilityEntity);

				var isUserInput  = requestComponent.IsUserInput;
				ref var slotType = ref requestComponent.AbilitySlot;
				ref var isDefault = ref requestComponent.IsDefault;
				ref var abilityId = ref requestComponent.AbilityId;
				var packedAbility =  _world.PackEntity(abilityEntity);

				if (!ownerComponent.Value.Unpack(_world, out var ownerAbilityEntity))
					continue;
				
				ref var abilityMapComponent = ref _abilityOwnerAspect.AbilityMap.Get(ownerAbilityEntity);

				if (slotType >= 0)
				{
					var abilitySlotEntity = abilityMapComponent.Abilities[slotType];
					if (abilitySlotEntity.Unpack(_world, out var oldAbilityEntity))
						_removedEntities.Add(oldAbilityEntity);
					abilityMapComponent.Abilities[slotType] = packedAbility;
				}

				_abilityAspect.Active.Add(abilityEntity);

				if (isDefault)
				{
					_abilityAspect.Default.GetOrAddComponent(abilityEntity);
					_abilityTools.ChangeInHandAbility(_world,ownerAbilityEntity,abilityEntity);
				}
				
				if (isUserInput)
					_abilityAspect.Input.GetOrAddComponent(abilityEntity);

				var eventEntity = _world.NewEntity();
				ref var abilityEquipChangedEvent = ref _inventoryAspect.EquipChanged.Add(eventEntity);
				abilityEquipChangedEvent.AbilityId = abilityId;
				abilityEquipChangedEvent.AbilitySlot = slotType;
				abilityEquipChangedEvent.Owner = ownerComponent.Value;
				abilityEquipChangedEvent.AbilityEntity = packedAbility;
				
				_inventoryAspect.Building.Del(abilityEntity);
				_inventoryAspect.Equip.Del(abilityEntity);
			}
			
			foreach (var removedEntity in _removedEntities)
				_world.DelEntity(removedEntity);
		}
	}
}