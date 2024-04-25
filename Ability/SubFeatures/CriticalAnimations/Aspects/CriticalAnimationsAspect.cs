namespace unigame.ecs.proto.Ability.SubFeatures.CriticalAnimations.Aspects
{
	using System;
	using Ability.Components.Requests;
	using AbilityAnimation.Components;
	using Common.Components;
	using Components;
	using Game.Ecs.Core.Components;
	using Gameplay.CriticalAttackChance.Components;
	using Leopotam.EcsProto;
	using Target.Components;
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
		public ProtoPool<AbilityTargetsComponent> AbilityTargets;
		public ProtoPool<AbilityAnimationOptionComponent> AbilityAnimationOption;
		
		// requests
		public ProtoPool<ApplyAbilitySelfRequest> ApplyAbilitySelfRequest;
		public ProtoPool<CompleteAbilitySelfRequest> CompleteAbilitySelfRequest;
		public ProtoPool<RestartAbilityCooldownSelfRequest> RestartAbilityCooldownSelfRequest;
		public ProtoPool<ResetAbilityCooldownSelfRequest> ResetAbilityCooldownSelfRequest;
	}
}