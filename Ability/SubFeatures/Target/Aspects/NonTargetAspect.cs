namespace unigame.ecs.proto.Ability.SubFeatures.Target.Aspects
{
	using System;
	using Components;
	 
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Non target aspect.
	/// </summary>
	[Serializable]
	public class NonTargetAspect : EcsAspect
	{
		public ProtoPool<UntargetableComponent> NonTargetComponent;
		public ProtoPool<AbilityTargetsComponent> AbilityTargetsComponent;
	}
}