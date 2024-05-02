namespace UniGame.Ecs.Proto.AbilityInventory.Components
{
	using System.Collections.Generic;
	using Game.Code.Services.Ability.Data;

	public struct AbilityRarityMapComponent
	{
		public AbilityRaritySlot DisableSlot;
		public List<AbilityRaritySlot> Slots;
	}
}