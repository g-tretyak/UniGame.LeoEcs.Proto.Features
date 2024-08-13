namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Aspects
{
	using System;
	using Ability.Components.Requests;
	using AbilityAnimation.Components;
	using Common.Components;
	using Components;
	using Game.Ecs.Core.Components;
	using Gameplay.CriticalAttackChance.Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Critical animations aspect
	/// </summary>
	[Serializable]
	public class CriticalAnimationsAspect : EcsAspect
	{
		public ProtoPool<CriticalAbilityTargetComponent> CriticalAbilityTarget;
		public ProtoPool<CriticalAttackMarkerComponent> CriticalAttackMarker;
		public ProtoPool<OwnerComponent> Owner;
		public ProtoPool<AbilityAnimationOptionComponent> AbilityAnimationOption;
		public ProtoPool<CriticalAbilityOwnerComponent> CriticalAbilityOwner;
		public ProtoPool<AbilityCriticalAnimationTargetComponent> AbilityCriticalAnimationTarget;
		public ProtoPool<AbilityCriticalAnimationComponent> AbilityCriticalAnimation;
		
		// requests
		public ProtoPool<ApplyAbilitySelfRequest> ApplyAbilitySelfRequest;
		public ProtoPool<CompleteAbilitySelfRequest> CompleteAbilitySelfRequest;
		public ProtoPool<RestartAbilityCooldownSelfRequest> RestartAbilityCooldownSelfRequest;
		public ProtoPool<ResetAbilityCooldownSelfRequest> ResetAbilityCooldownSelfRequest;
		
	}
}