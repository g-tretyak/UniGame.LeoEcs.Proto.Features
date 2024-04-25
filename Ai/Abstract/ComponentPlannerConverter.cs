namespace unigame.ecs.proto.AI.Abstract
{
    using System;
    using Leopotam.EcsProto;
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Abstract;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public abstract class ComponentPlannerConverter : EcsComponentConverter, IEntityConverter
    {
        public void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            Apply(world, entity);
            OnApply(target, world, entity);
        }

        protected virtual void OnApply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {

        }
    }
    
    [Serializable]
    public class ComponentPlannerConverter<TComponent> : ComponentPlannerConverter
        where TComponent : struct, IApplyableComponent<TComponent>
    {
        [FoldoutGroup(nameof(data))]
        [InlineProperty]
        [SerializeField]
        [HideLabel]
        public TComponent data;
    
        protected override void OnApply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var component = ref world.GetOrAddComponent<TComponent>(entity);
            data.Apply(ref component);
        }

        public override void Apply(ProtoWorld world, ProtoEntity entity)
        {
            
        }
    }
}