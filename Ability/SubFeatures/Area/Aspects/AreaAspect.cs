namespace UniGame.Ecs.Proto.Ability.SubFeatures.Area.Aspects
{
    using System;
    using Components;
    using Game.Ecs.Core.Components;
    using GameLayers.Category.Components;
    using GameLayers.Layer.Components;
    using GameLayers.Relationship.Components;
    using Leopotam.EcsProto;
    using Target.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Components;


#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class AreaAspect : EcsAspect
    {
        public ProtoPool<AreaLocalPositionComponent> AreaPosition;
        public ProtoPool<AreableAbilityComponent> AreableAbility;
        public ProtoPool<AreaRadiusComponent> AreaRadius;
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<AbilityTargetsComponent> Targets;
        public ProtoPool<RelationshipIdComponent> Relationship;
        public ProtoPool<CategoryIdComponent> Category;
        public ProtoPool<TransformPositionComponent> Position;
        public ProtoPool<LayerIdComponent> Layer;
        public ProtoPool<CanLookAtComponent> CanLookAtPool;
    }
}