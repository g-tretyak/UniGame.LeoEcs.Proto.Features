namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySwitcher.Behaviours
{
	using System;
	using Abstracts;
	using Components;
	using Game.Code.Configuration.Runtime.Ability.Description;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

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
		public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
		{
			world.AddComponent<AbilitySwitcherComponent>(abilityEntity);
			configuration.Compose(world, abilityEntity);
		}
	}
}