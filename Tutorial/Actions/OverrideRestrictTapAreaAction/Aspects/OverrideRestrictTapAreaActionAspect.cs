namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.OverrideRestrictTapAreaAction.Aspects
{
	using System;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
	
	[Serializable]
	public class OverrideRestrictTapAreaActionAspect : EcsAspect
	{
		public ProtoPool<OverrideRestrictTapAreaActionComponent> OverrideRestrictTapAreaAction;
		public ProtoPool<OverrideRestrictTapAreaActionReadyComponent> OverrideRestrictTapAreaActionReady;
	}
}