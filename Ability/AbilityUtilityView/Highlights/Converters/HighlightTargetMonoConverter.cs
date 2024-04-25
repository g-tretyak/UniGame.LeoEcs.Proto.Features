namespace unigame.ecs.proto.Ability.AbilityUtilityView.Highlights.Converters
{
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class HighlightTargetMonoConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        public GameObject highlight;

        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var highlightPool = world.GetPool<HighlightComponent>();
            ref var highlightComponent = ref highlightPool.Add(entity);
            
            highlightComponent.Highlight = highlight;
        }
    }
}