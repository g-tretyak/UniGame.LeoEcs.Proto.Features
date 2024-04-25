namespace unigame.ecs.proto.Ability.SubFeatures.Target.Aspects
{
	using System;
	using Characteristics.SplashDamage.Components;
	using Components;
	using Core.Components;
	using Core.Death.Components;
	 
	using Movement.Components;
	using Selection.Components;
	using UniGame.LeoEcs.Shared.Components;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Target aspect.
	/// </summary>
	[Serializable]
	public class TargetAbilityAspect : EcsAspect
	{
		public ProtoPool<SoloTargetComponent> SoloTarget;
		public ProtoPool<MultipleTargetsComponent> MultipleTargets;
		public ProtoPool<AbilityTargetsComponent> AbilityTargets;
		public ProtoPool<SplashEffectSourceComponent> SplashApplyEffects;
		public ProtoPool<OwnerComponent> Owner;
		public ProtoPool<SplashDamageComponent> SplashCharacteristics;
		public ProtoPool<PrepareToDeathComponent> PrepareToDeath;
		public ProtoPool<DisabledComponent> Disabled;
		public ProtoPool<SelectedTargetsComponent> SelectedTargets;
		
		public ProtoPool<TransformComponent> Transform;
		public ProtoPool<TransformPositionComponent> Position;
		public ProtoPool<TransformDirectionComponent> Direction;
		
		public ProtoPool<EntityAvatarComponent> Avatar;
		public ProtoPool<UnderTheTargetComponent> UnderTheTarget;
		public ProtoPool<CanLookAtComponent> CanLookAt;
		
		//requests
		public ProtoPool<RotateToPointSelfRequest> RotateTo;
	}
}