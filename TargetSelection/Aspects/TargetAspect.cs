namespace unigame.ecs.proto.TargetSelection.Aspects
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class TargetAspect : EcsAspect
    {
        public ProtoPool<KDTreeDataComponent> Data;
        public ProtoPool<KDTreeComponent> Tree;
        public ProtoPool<KDTreeQueryComponent> Query;
        public ProtoPool<TransformComponent> Transform;
        public ProtoPool<TransformPositionComponent> Position;
    }
}