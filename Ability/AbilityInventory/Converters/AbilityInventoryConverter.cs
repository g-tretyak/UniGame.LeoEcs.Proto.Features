namespace UniGame.Ecs.Proto.AbilityInventory.Converters
{
	using System;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Converter.Runtime;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class AbilityInventoryConverter : LeoEcsConverter
	{
		[SerializeField]
		public bool userInput;
		
		public bool autoEquipByProfile = true;
		
		public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
		{
			world.GetOrAddComponent<AbilityInventoryComponent>(entity);
			if(autoEquipByProfile)
				world.GetOrAddComponent<AbilityInventoryProfileComponent>(entity);
		}
	}
}