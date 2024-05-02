namespace UniGame.Ecs.Proto.Gameplay.Tutorial.Triggers.ActionTrigger
{
	using Abstracts;
	using ActionTools;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;

	public class ActionTriggerConfiguration : TutorialTrigger
	{
		#region Inspector
        
		public ActionId actionId;

		#endregion
		
		protected override void Composer(ProtoWorld world, ProtoEntity entity)
		{
			ref var actionTriggerComponent = ref world.AddComponent<ActionTriggerComponent>(entity);
			actionTriggerComponent.ActionId = actionId;
		}
	}
}