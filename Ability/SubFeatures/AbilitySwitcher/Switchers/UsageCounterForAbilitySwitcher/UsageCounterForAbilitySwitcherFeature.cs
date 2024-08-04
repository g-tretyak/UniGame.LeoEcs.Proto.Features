namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySwitcher.Switchers.UsageCounterForAbilitySwitcher
{
	using System;
	using AbilitySequence.Tools;
	using Cysharp.Threading.Tasks;
	using Leopotam.EcsProto;
	using UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySwitcher.Abstracts;
	 
	using Systems;
	using Tools;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	/// <summary>
	/// Feature for ability switcher that uses counter to switch between abilities.
	/// </summary>
	[Serializable]
	[CreateAssetMenu(menuName = "Proto Features/Ability/AbilitySwitcherConfigurations/Usage Counter Ability Switcher Feature", 
		fileName = "Usage Counter Ability Switcher Feature")]
	public class UsageCounterForAbilitySwitcherFeature : AbilitySwitcherAssetFeature
	{
		private AbilitySequenceTools _abilitySequenceTools;
		
		public override async UniTask InitializeAsync(IProtoSystems ecsSystems)
		{
			var world = ecsSystems.GetWorld();
			_abilitySequenceTools = world.GetGlobal<AbilitySequenceTools>();
			
			// Counts usages of ability and switches it to another ability after count of usages.
			ecsSystems.Add(new UsageCounterForAbilitySwitcherSystem());
		}
	}
}