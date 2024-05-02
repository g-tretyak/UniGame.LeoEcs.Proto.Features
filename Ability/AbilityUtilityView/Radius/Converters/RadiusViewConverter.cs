namespace UniGame.Ecs.Proto.Ability.AbilityUtilityView.Radius.Converters
{
    using System;
    using Component;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class RadiusViewConverter : LeoEcsConverter
    {
        [SerializeField]
        public GameObject noTargetRadiusView;
        [SerializeField]
        public GameObject hasTargetRadiusView;

        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var radiusViewPool = world.GetPool<RadiusViewDataComponent>();
            ref var radiusView = ref radiusViewPool.Add(entity);
            
            radiusView.InvalidRadiusView = noTargetRadiusView;
            radiusView.ValidRadiusView = hasTargetRadiusView;
        }
    }
}