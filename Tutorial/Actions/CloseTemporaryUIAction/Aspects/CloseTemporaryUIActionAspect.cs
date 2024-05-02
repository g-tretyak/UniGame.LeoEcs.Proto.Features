namespace UniGame.Ecs.Proto.Gameplay.Tutorial.Actions.CloseTemporaryUIAction.Aspects
{
	using System;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	[Serializable]
	public class CloseTemporaryUIActionAspect : EcsAspect
	{
		public ProtoPool<CompletedCloseTemporaryUIActionComponent> CompletedCloseTemporaryUIAction;
	}
}