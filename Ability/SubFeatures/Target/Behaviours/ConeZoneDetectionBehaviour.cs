namespace unigame.ecs.proto.Ability.SubFeatures.Target.Behaviours
{
	using System;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class ConeZoneDetectionBehaviour : IAbilityBehaviour, ILeoEcsGizmosDrawer
	{
		public float angle;
		public float distance;
		
		public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
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