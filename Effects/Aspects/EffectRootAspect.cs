namespace UniGame.Ecs.Proto.Effects.Aspects
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class EffectRootAspect : EcsAspect
    {
        public ProtoPool<EffectRootTransformsComponent> Target;
        public ProtoPool<EffectRootIdComponent> Id;
        public ProtoPool<TransformComponent> Transform;
        public ProtoPool<TransformPositionComponent> Position;
    }
}