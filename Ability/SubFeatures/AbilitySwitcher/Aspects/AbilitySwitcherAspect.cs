namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySwitcher.Aspects
{
	using System;
	using Ability.Components.Requests;
	using Common.Components;
	using Components;
	using Core.Components;
	 
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Ability switcher aspect
	/// </summary>
	[Serializable]
	public class AbilitySwitcherAspect : EcsAspect
	{
		public ProtoPool<OwnerComponent> Owner;
		
		// requests
		public ProtoPool<AbilitySwitcherRequest> AbilitySwitchRequest;
		public ProtoPool<CompleteAbilitySelfRequest> CompleteAbilitySelfRequest;
		public ProtoPool<RestartAbilityCooldownSelfRequest> RestartAbilityCooldownSelfRequest;
		public ProtoPool<ResetAbilityCooldownSelfRequest> ResetAbilityCooldownSelfRequest;
	}
}