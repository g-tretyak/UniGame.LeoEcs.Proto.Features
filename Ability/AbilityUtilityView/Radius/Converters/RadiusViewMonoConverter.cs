namespace unigame.ecs.proto.Ability.AbilityUtilityView.Radius.Converters
{
    using Component;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    
    public sealed class RadiusViewMonoConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        private GameObject noTargetRadiusView;
        [SerializeField]
        private GameObject hasTargetRadiusView;

        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var radiusViewPool = world.GetPool<RadiusViewDataComponent>();
            ref var radiusView = ref radiusViewPool.Add(entity);
            
            radiusView.InvalidRadiusView = noTargetRadiusView;
            radiusView.ValidRadiusView = hasTargetRadiusView;
        }
    }
}