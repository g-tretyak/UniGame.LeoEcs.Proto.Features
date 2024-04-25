namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.EquipAbilityAction.Aspects
{
	using System;
	using AbilityInventory.Components;
	using Components;
	using Core.Components;
	 
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	[Serializable]
	public class EquipAbilityActionAspect : EcsAspect
	{
		public ProtoPool<EquipAbilityActionComponent> EquipAbilityAction;
		public ProtoPool<EquipAbilityIdSelfRequest> EquipAbilityIdRequest;
		public ProtoPool<CompletedEquipAbilityActionComponent> CompletedEquipAbilityAction;
		public ProtoPool<ChampionComponent> Champion;
	}
}