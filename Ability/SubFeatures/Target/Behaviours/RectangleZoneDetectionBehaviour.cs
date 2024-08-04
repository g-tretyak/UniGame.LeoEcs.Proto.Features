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
    public sealed class RectangleZoneDetectionBehaviour : IAbilityBehaviour, ILeoEcsGizmosDrawer
    {
        public Vector2 offset;
        public Vector2 size;
        
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
        {
            var zoneDetectionPool = world.GetPool<RectangleZoneDetectionComponent>();
            ref var zoneDetectionComponent = ref zoneDetectionPool.Add(abilityEntity);
            zoneDetectionComponent.Offset = offset;
            zoneDetectionComponent.Size = size;
        }

        public void DrawGizmos(GameObject target)
        {
#if UNITY_EDITOR
            ZoneDetectionMathTool.DrawGizmos(target, offset, size);
#endif
        }
    }
}