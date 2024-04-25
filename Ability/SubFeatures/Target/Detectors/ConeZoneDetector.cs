namespace unigame.ecs.proto.Ability.SubFeatures.Target.Detectors
{
    using System;
    using System.Collections.Generic;
    using Abstract;
    using Game.Code.GameTools.Runtime;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public class ConeZoneDetector : IZoneTargetsDetector
    {
        public float _angle;
        public float _distance;

        private HashSet<ProtoEntity> _targetMap = new HashSet<ProtoEntity>();
        
        public int GetTargetsInZone(ProtoWorld world,
            ProtoEntity[] result, ProtoEntity entity, 
            ProtoEntity[] targets,int amount)
        {
            _targetMap.Clear();
            
            var transformPool = world.GetPool<TransformPositionComponent>();
            var directionPool = world.GetPool<TransformDirectionComponent>();
            
            ref var transformComponentSource = ref transformPool.Get(entity);
            ref var directionComponentSource = ref directionPool.Get(entity);
            
            ref var transformSource = ref directionComponentSource.Forward;
            ref var sourcePosition = ref transformComponentSource.Position;

            var counter = 0;
            
            for (int i = 0; i < amount; i++)
            {
                var targetEntity = targets[i];
                if(_targetMap.Contains(targetEntity)) continue;
                if (!transformPool.Has(targetEntity)) continue;
                
                ref var transformTargetComponent = ref transformPool.Get(targetEntity);
                ref var positionTarget = ref transformTargetComponent.Position;
                
                if (!ZoneDetectionMathTool.IsPointWithin(positionTarget,
                        sourcePosition,
                        transformSource, _angle, _distance)) continue;
                
                result[counter] = targetEntity;
                counter++;
            }

            return counter;
        }
    }
}