namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Aspects
{
	using System;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Non target aspect.
	/// </summary>
	[Serializable]
	public class NonTargetAspect : EcsAspect
	{
		public ProtoPool<UntargetableComponent> NonTargetComponent;
		public ProtoPool<NonTargetAbilityComponent> NonTargetAbilityComponent;
		public ProtoPool<AbilityTargetsComponent> AbilityTargetsComponent;
		public ProtoPool<RectangleZoneDetectionComponent> RectangleZoneDetectionComponent;
		public ProtoPool<CircleZoneDetectionComponent> CircleZoneDetectionComponent;
		public ProtoPool<ConeZoneDetectionComponent> ConeZoneDetectionComponent;
		public ProtoPool<EmptyTargetComponent> EmptyTarget;
	}
}