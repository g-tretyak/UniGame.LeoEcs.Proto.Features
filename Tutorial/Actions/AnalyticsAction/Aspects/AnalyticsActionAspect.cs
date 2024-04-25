namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.AnalyticsAction.Aspects
{
	using System;
	using Components;
	 
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	[Serializable]
	public class AnalyticsActionAspect : EcsAspect
	{
		public ProtoPool<AnalyticsActionComponent> AnalyticsAction;
		public ProtoPool<CompletedAnalyticsActionComponent> CompletedAnalyticsAction;
	}
}