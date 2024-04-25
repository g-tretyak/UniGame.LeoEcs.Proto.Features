namespace unigame.ecs.proto.Gameplay.Tutorial.Triggers.ActionTrigger
{
	using System;
	using Abstracts;
	using ActionTools;
	using Components;
	 
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine.Serialization;
    
	public class ActionTriggerConfiguration : TutorialTrigger
	{
		#region Inspector
        
		public ActionId actionId;

		#endregion
		
		protected override void Composer(ProtoWorld world, int entity)
		{
			ref var actionTriggerComponent = ref world.AddComponent<ActionTriggerComponent>(entity);
			actionTriggerComponent.ActionId = actionId;
		}
	}
}