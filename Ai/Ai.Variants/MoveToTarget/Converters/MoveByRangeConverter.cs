namespace UniGame.Ecs.Proto.GameAi.MoveToTarget.Converters
{
    using System;
    using System.Collections.Generic;
    using AI.Abstract;
    using Components;
    using Game.Code.Configuration.Runtime.Effects.Abstract;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class MoveByRangeConverter : ComponentPlannerConverter, IMoveByConverter,ILeoEcsGizmosDrawer
    {
        [SerializeField]
        private float _priority;
        [SerializeField]
        private float _radius;
        [SerializeField]
        private float _minDistance = 0.5f;
        [SerializeReference]
        private List<IEffectConfiguration> _effects = new List<IEffectConfiguration>();

        public Color rangeGizmosColor = Color.red;

        public override void Apply(ProtoWorld world, ProtoEntity entity)
        {
            
        }

        protected override void OnApply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var component = ref world.AddComponent<MoveByRangeComponent>(entity);

            component.Center = target.transform.position;
            component.Priority = _priority;
            component.Radius = _radius;
            component.MinDistance = _minDistance;
            component.Effects = _effects;
        }

        public void DrawGizmos(GameObject target)
        {

        }
    }
}