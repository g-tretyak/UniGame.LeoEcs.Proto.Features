namespace UniGame.Ecs.Proto.AbilityInventory.Converters
{
	/// <summary>
	/// Convert ability meta data to entity
	/// </summary>
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
		
		private AbilityInventoryAspect _inventoryAspect;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
		}
		
		


	}
}