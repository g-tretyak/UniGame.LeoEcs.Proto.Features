namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySwitcher.Switchers.TimerForAbilitySwitcher
{
	using System;
	using Abstracts;
	using Cysharp.Threading.Tasks;
	using Leopotam.EcsProto;
	using Systems;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	/// <summary>
	/// Feature for ability switcher that uses counter to switch between abilities.
	/// </summary>
	[Serializable]
	[CreateAssetMenu(menuName = "Game/Feature/Ability/AbilitySwitcherConfigurations/Timer Ability Switcher Feature", 
		fileName = "Timer Ability Switcher Feature")]
	public class TimerForAbilitySwitcherFeature : AbilitySwitcherAssetFeature
	{
		public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
		{
			// Evaluate timer for ability switcher. Set ready if timer is over.
			ecsSystems.Add(new EvaluateTimerForAbilitySwitcherSystem());
			// Switch ability if timer is ready.Await ApplyAbilitySelfRequest
			// and TimerForAbilitySwitcherReadyComponent
			ecsSystems.Add(new TimerForAbilitySwitcherSystem());
		}
	}
}