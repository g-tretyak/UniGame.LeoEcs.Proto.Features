namespace UniGame.Ecs.Proto.Ability.SubFeatures.Target.Behaviours
{
	using System;
	using Components;
	using Game.Code.Configuration.Runtime.Ability.Description;
	using Game.Code.GameTools.Runtime;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Converter.Runtime.Abstract;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class ConeZoneDetectionBehaviour : IAbilityBehaviour, ILeoEcsGizmosDrawer
	{
		public float angle;
		public float distance;
		
		public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
		{
			var zoneDetectionPool = world.GetPool<ConeZoneDetectionComponent>();
			ref var zoneDetectionComponent = ref zoneDetectionPool.Add(abilityEntity);
			zoneDetectionComponent.Angle = angle;
			zoneDetectionComponent.Distance = distance;
		}

		public void DrawGizmos(GameObject target)
		{
#if UNITY_EDITOR
			ZoneDetectionMathTool.DrawGizmos(target, angle, distance);
#endif
		}
	}
}