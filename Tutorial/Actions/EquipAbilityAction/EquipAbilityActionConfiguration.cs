namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.EquipAbilityAction
{
	using System.Collections.Generic;
	using Abstracts;
	using Components;
	using Game.Code.Configuration.Runtime.Ability;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;


	public class EquipAbilityActionConfiguration : TutorialAction
	{
		#region Inspector
        
		public List<AbilityCell> abilityCells;

		#endregion
		
		protected override void Composer(ProtoWorld world, ProtoEntity entity)
		{
			ref var equipAbilityActionComponent = ref world.AddComponent<EquipAbilityActionComponent>(entity);
			equipAbilityActionComponent.AbilityCells.AddRange(abilityCells);
		}
	}
}