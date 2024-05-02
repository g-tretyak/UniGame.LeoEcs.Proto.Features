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
	public sealed class CircleZoneDetectionBehaviour : IAbilityBehaviour, ILeoEcsGizmosDrawer
	{
		public Vector2 offset;
		public float radius;
		
		public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
		{
			var zoneDetectionPool = world.GetPool<CircleZoneDetectionComponent>();
            ref var zoneDetectionComponent = ref zoneDetectionPool.Add(abilityEntity);
            zoneDetectionComponent.Offset = offset;
            zoneDetectionComponent.Radius = radius;
		}

		public void DrawGizmos(GameObject target)
		{
#if UNITY_EDITOR
			ZoneDetectionMathTool.DrawGizmos(target, offset, radius);
#endif
		}
	}
}