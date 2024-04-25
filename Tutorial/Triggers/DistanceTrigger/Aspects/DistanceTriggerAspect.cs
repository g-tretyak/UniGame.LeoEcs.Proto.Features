namespace unigame.ecs.proto.Gameplay.Tutorial.Triggers.DistanceTrigger.Aspects
{
	using unigame.ecs.proto.Gameplay.Tutorial.Components;
	using Components;
	using Core.Components;
	 
	using UniGame.LeoEcs.Shared.Components;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	public class DistanceTriggerAspect : EcsAspect
	{
		public ProtoWorld World;
		
		public ProtoPool<DistanceTriggerPointComponent> DistanceTriggerPoint;
		public ProtoPool<CompletedDistanceTriggerPointComponent> CompletedDistanceTriggerPoint;
		public ProtoPool<TransformPositionComponent> Position;
		public ProtoPool<OwnerComponent> Owner;
		public ProtoPool<RunTutorialActionsRequest> RunTutorialActionsRequest;
	}
}