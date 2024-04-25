namespace unigame.ecs.proto.Ability.SubFeatures.Target.Behaviours
{
    using System;
    using Code.Configuration.Runtime.Ability.Description;
    using Code.GameTools.Runtime;
    using Components;
     
    using UniGame.LeoEcs.Converter.Runtime.Abstract;
    using UnityEngine;

    [Serializable]
    public sealed class RectangleZoneDetectionBehaviour : IAbilityBehaviour, ILeoEcsGizmosDrawer
    {
        public Vector2 offset;
        public Vector2 size;
        
        public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
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