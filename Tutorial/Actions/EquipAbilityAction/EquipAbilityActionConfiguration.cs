namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.EquipAbilityAction
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Abstracts;
	using Code.Configuration.Runtime.Ability;
	using Code.Services.AbilityLoadout.Data;
	using Components;
	 
	using Sirenix.OdinInspector;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;


	public class EquipAbilityActionConfiguration : TutorialAction
	{
		#region Inspector
        
		public List<AbilityCell> abilityCells;

		#endregion
		
		protected override void Composer(ProtoWorld world, int entity)
		{
			ref var equipAbilityActionComponent = ref world.AddComponent<EquipAbilityActionComponent>(entity);
			equipAbilityActionComponent.AbilityCells.AddRange(abilityCells);
		}
	}
}