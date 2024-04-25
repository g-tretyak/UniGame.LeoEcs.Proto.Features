namespace unigame.ecs.proto.Effects.Data
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class EffectTargetAspect : EcsAspect
    {
        public ProtoPool<EffectRootTargetComponent> Target;
        public ProtoPool<EffectParentComponent> Transform;
        public ProtoPool<EffectRootIdComponent> Id;
    }
}