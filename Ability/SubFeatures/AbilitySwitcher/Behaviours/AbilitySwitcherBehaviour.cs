namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySwitcher.Behaviours
{
	using System;
	using Abstracts;
	using Code.Configuration.Runtime.Ability.Description;
	using Components;
	 
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;
	using UnityEngine.Serialization;

	/// <summary>
	/// Adds ability capability to switch between abilities.  
	/// </summary>
	[Serializable]
	public class AbilitySwitcherBehaviour : IAbilityBehaviour
	{
		#region Inspector
		
		[SerializeReference]
		public IAbilitySwitcherConfiguration configuration;

		#endregion
		public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
		{
			world.AddComponent<AbilitySwitcherComponent>(abilityEntity);
			configuration.Compose(world, abilityEntity);
		}
	}
}