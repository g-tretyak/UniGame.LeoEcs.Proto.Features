namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.OpenWindowAction.Aspects
{
	using Components;
	 
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	public class OpenWindowActionAspect : EcsAspect
	{
		public ProtoPool<OpenWindowActionComponent> OpenWindowAction;
		public ProtoPool<CompletedOpenWindowActionComponent> CompletedOpenWindowAction;
	}
}