namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.OverrideRestrictTapAreaAction.Aspects
{
	using System;
	using Components;
	 
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// ADD DESCRIPTION HERE
	/// </summary>
	[Serializable]
	public class OverrideRestrictTapAreaActionAspect : EcsAspect
	{
		public ProtoPool<OverrideRestrictTapAreaActionComponent> OverrideRestrictTapAreaAction;
		public ProtoPool<OverrideRestrictTapAreaActionReadyComponent> OverrideRestrictTapAreaActionReady;
	}
}