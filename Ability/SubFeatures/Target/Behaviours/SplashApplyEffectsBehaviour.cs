namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Behaviours
{
	using System;
	using System.Collections.Generic;
	using Abstract;
	using Components;
	using Game.Code.Configuration.Runtime.Ability.Description;
	using Game.Code.Configuration.Runtime.Effects.Abstract;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class SplashApplyEffectsBehaviour : IAbilityBehaviour
	{
		[SerializeReference]
		public IZoneTargetsDetector zoneTargetsDetector;
		[SerializeReference]
		public List<IEffectConfiguration> mainTargetEffects = new();
		[SerializeReference]
		public List<IEffectConfiguration> otherTargetsEffects = new();

		public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
		{
			var splashPool = world.GetPool<SplashEffectSourceComponent>();
			ref var splashComponent = ref splashPool.Add(abilityEntity);
			splashComponent.MainTargetEffects.AddRange(mainTargetEffects);
			splashComponent.OtherTargetsEffects.AddRange(otherTargetsEffects);
			splashComponent.ZoneTargetsDetector = zoneTargetsDetector;
		}
	}
}