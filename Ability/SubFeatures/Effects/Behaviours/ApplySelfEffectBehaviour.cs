namespace unigame.ecs.proto.Ability.SubFeatures.Effects.Behaviours
{
	using System;
	using System.Collections.Generic;
	using Game.Code.Configuration.Runtime.Ability.Description;
	using Leopotam.EcsProto;
	using UnityEngine;

	[Serializable]
	public class ApplySelfEffectBehaviour : IAbilityBehaviour
	{
		[SerializeReference] 
		public List<IEffectConfiguration> Effects = new List<IEffectConfiguration>();
		
		public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
		{
			var selfEffectsPool = world.GetPool<SelfEffectsComponent>();
			ref var effectsComponent = ref selfEffectsPool.Add(abilityEntity);
			effectsComponent.Effects.AddRange(Effects);
		}
	}
}