namespace UniGame.Ecs.Proto.Ability.SubFeatures.Effects.Behaviours
{
	using System;
	using System.Collections.Generic;
	using Game.Code.Configuration.Runtime.Ability.Description;
	using Game.Code.Configuration.Runtime.Effects.Abstract;
	using Leopotam.EcsProto;
	using Proto.Effects.Components;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class ApplySelfEffectBehaviour : IAbilityBehaviour
	{
		[SerializeReference] 
		public List<IEffectConfiguration> Effects = new();
		
		public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
		{
			var selfEffectsPool = world.GetPool<SelfEffectsComponent>();
			ref var effectsComponent = ref selfEffectsPool.Add(abilityEntity);
			effectsComponent.Effects.AddRange(Effects);
		}
	}
}