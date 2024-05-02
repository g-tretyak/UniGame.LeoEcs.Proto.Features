namespace UniGame.Ecs.Proto.Ability.SubFeatures.ComeToTarget.Aspects
{
    using System;
    using Characteristics.Radius.Component;
    using Components;
    using Game.Ecs.Core.Components;
    using Game.Ecs.Core.Death.Components;
    using Leopotam.EcsProto;
    using Movement.Components;
    using Target.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Components;

    [Serializable]
    public class ComeFromTargetAspect : EcsAspect
    {
        public ProtoPool<UpdateComePointComponent> Update;
        public ProtoPool<AbilityTargetsComponent> Targets;
        public ProtoPool<TransformComponent> Transform;
        public ProtoPool<TransformPositionComponent> Position;
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<RadiusComponent> Radius;
        public ProtoPool<EntityAvatarComponent> Avatar;
        public ProtoPool<DeferredAbilityComponent> Deferred;
        public ProtoPool<ComePointComponent> Point;
        public ProtoPool<RevokeComeToEndOfRequest> Revoke;
        public ProtoPool<DestroyComponent> Dead;
    }
}