namespace UniGame.Ecs.Proto.Effects.Aspects
{
    using System;
    using Characteristics.AbilityPower.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class EffectAspect : EcsAspect
    {
        public ProtoPool<EffectComponent> Effect;
        public ProtoPool<EffectsListComponent> List;
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<AbilityPowerComponent> Power;
        public ProtoPool<EffectViewDataComponent> ViewData;
        public ProtoPool<EffectDurationComponent> Duration;
        public ProtoPool<EffectParentComponent> Parent;
        public ProtoPool<EffectPeriodicityComponent> Periodicity;
        public ProtoPool<DelayedEffectComponent> Delayed;
        public ProtoPool<CompletedDelayedEffectComponent> CompletedDelayed;
        
        
        //optional
        public ProtoPool<EffectViewComponent> View;
        public ProtoPool<EffectRootTransformsComponent> Transforms;
        public ProtoPool<EntityAvatarComponent> Avatar;
        public ProtoPool<EffectRootIdComponent> EffectRootId;
        public ProtoPool<EffectShowCompleteComponent> ShowComplete;
        public ProtoPool<TransformPositionComponent> Position;
        public ProtoPool<TransformComponent> Transform;
        
        //Events
        public ProtoPool<EffectAppliedSelfEvent> EffectAppliedSelfEvent;

        //requests
        public ProtoPool<CreateEffectSelfRequest> Create;
        public ProtoPool<DestroyEffectViewSelfRequest> DestroyView;
        public ProtoPool<DestroyEffectSelfRequest> DestroyEffect;
        public ProtoPool<ApplyEffectSelfRequest> Apply;
        
    }
}