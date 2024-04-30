namespace unigame.ecs.proto.Movement.Aspect
{
    using System;
    using Characteristics.Speed.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Input.Components.Direction;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class NavMeshAgentAspect : EcsAspect
    {
        public ProtoPool<NavMeshAgentComponent> Agent;
        public ProtoPool<RigidbodyComponent> Rigidbody;
        public ProtoPool<TransformComponent> Transform;
        public ProtoPool<TransformPositionComponent> Position;
        public ProtoPool<VelocityComponent> Velocity;
        public ProtoPool<SpeedComponent> Speed;
        public ProtoPool<AngularSpeedComponent> RotationSpeed;
        
        public ProtoPool<ImmobilityComponent> Immobility;
        public ProtoPool<DirectionInputEvent> Direction;
        public ProtoPool<StepMovementComponent> StepMovement;
        
        public ProtoPool<ComePointComponent> ComePoint;
        public ProtoPool<InstantRotateComponent> InstantRotate;

        //requests
        public ProtoPool<MovementPointSelfRequest> MovementTargetPoint;
        public ProtoPool<MovementStopSelfRequest> NavMeshAgentStop;
        public ProtoPool<RotateToPointSelfRequest> RotateTo;
        public ProtoPool<SetNavigationStatusSelfRequest> SetNavigationStatus;
        public ProtoPool<SetKinematicSelfRequest> SetKinematicStatus;
        


    }
}