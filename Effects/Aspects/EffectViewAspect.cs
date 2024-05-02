namespace UniGame.Ecs.Proto.Effects.Aspects
{
    using System;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class EffectViewAspect : EcsAspect
    {
        public ProtoPool<EffectViewComponent> View;
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<EffectParentComponent> Parent;
    }
}