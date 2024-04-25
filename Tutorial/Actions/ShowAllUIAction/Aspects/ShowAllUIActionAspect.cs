namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.ShowAllUIAction.Aspects
{
	using System;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	[Serializable]
	public class ShowAllUIActionAspect : EcsAspect
	{
		public ProtoPool<ShowAllUIActionComponent> ShowAllUIAction;
		public ProtoPool<ShowAllUIActionEvent> ShowAllUIActionEvent;
		public ProtoPool<CompletedShowAllUIComponent> CompletedShowAllUI;
	}
}