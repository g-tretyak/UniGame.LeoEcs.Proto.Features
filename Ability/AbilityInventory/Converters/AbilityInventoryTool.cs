namespace UniGame.Ecs.Proto.AbilityInventory.Converters
{
	/// <summary>
	/// Convert ability meta data to entity
	/// </summary>
	using AbilityUnlock.Components;
	using Aspects;
	using Components;
	using Game.Code.Configuration.Runtime.Ability.Description;
	using Game.Code.Services.AbilityLoadout.Data;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;
	[ECSDI]
	public class AbilityInventoryTool : IEcsSystem, IProtoInitSystem
	{
		private ProtoWorld _world;
		private AbilityMetaAspect _metaAspect;
		private AbilityInventoryAspect _inventoryAspect;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
		}
		
		public int Convert(AbilityItemData itemData,int entity)
		{
			var data = itemData.data;
			
			ref var abilityIdComponent = ref _metaAspect.Id.GetOrAddComponent(entity);
			ref var abilityMetaComponent = ref _metaAspect.Meta.GetOrAddComponent(entity);
			ref var abilityConfigurationComponent = ref _metaAspect.ConfigurationReference.GetOrAddComponent(entity);
			ref var visualDescriptionComponent = ref _metaAspect.Visual.GetOrAddComponent(entity);
			ref var nameComponent = ref _metaAspect.Name.GetOrAddComponent(entity);
			ref var abilitySlotTypeComponent = ref _inventoryAspect.Slot.GetOrAddComponent(entity);
			
			abilityConfigurationComponent.AbilityConfiguration = itemData.configurationReference;

			var visualDescription = itemData.visualDescription;
			visualDescriptionComponent.Name = visualDescription.Name;
			visualDescriptionComponent.Description = visualDescription.Description;
			visualDescriptionComponent.ManaCost = visualDescription.manaCost;
			visualDescriptionComponent.Icon = visualDescription.icon;
	
			nameComponent.Value = visualDescription.Name;
			abilityMetaComponent.AbilityId = itemData.id;
			abilityMetaComponent.SlotType = data.slotType;
			abilityMetaComponent.Hide = data.isHidden;
			abilityMetaComponent.IsBlocked = data.isBlock;
			
			if (data.isHidden)
				_world.AddComponent<AbilityInventoryHideComponent>(entity);
			
			if (data.isBlock)
				_metaAspect.Blocked.Add(entity);
			
			abilityIdComponent.AbilityId = (AbilityId)itemData.id;
			abilitySlotTypeComponent.SlotType = data.slotType;

			ref var abilityUnlockLevelComponent = ref _world
				.GetOrAddComponent<AbilityUnlockLevelComponent>(entity);
			abilityUnlockLevelComponent.Level = data.unlockLevel;

			return entity;
		}


	}
}