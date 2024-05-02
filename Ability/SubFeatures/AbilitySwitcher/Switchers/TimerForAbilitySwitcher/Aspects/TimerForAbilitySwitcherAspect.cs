namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySwitcher.Switchers.TimerForAbilitySwitcher.Aspects
{
	using System;
	using AbilitySwitcher.Components;
	using Common.Components;
	using Components;
	using Game.Ecs.Core.Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

	/// <summary>
	/// Aspect for ability switcher that uses counter to switch between abilities.
	/// </summary>
	[Serializable]
	public class TimerForAbilitySwitcherAspect : EcsAspect
	{
		// Timer for ability switcher component.
		public ProtoPool<TimerForAbilitySwitcherComponent> TimerForAbilitySwitcherComponent;
		// Marker component for ability switcher that uses counter to switch between abilities.
		public ProtoPool<TimerForAbilitySwitcherReadyComponent> TimerForAbilitySwitcherReadyComponent;
		// Says whose ability is currently active 
		public ProtoPool<OwnerComponent> OwnerComponent;
		
		//Requests
		// Request to switch ability
		public ProtoPool<AbilitySwitcherRequest> AbilitySwitchRequest;
		// Request to apply ability to self
		public ProtoPool<ApplyAbilitySelfRequest> ApplyAbilitySelfRequest;
	}
}