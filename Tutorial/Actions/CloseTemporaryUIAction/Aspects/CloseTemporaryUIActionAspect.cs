namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.CloseTemporaryUIAction.Aspects
{
	using System;
	using Components;
	 
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	[Serializable]
	public class CloseTemporaryUIActionAspect : EcsAspect
	{
		public ProtoPool<CompletedCloseTemporaryUIActionComponent> CompletedCloseTemporaryUIAction;
	}
}