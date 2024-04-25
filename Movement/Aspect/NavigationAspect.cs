namespace unigame.ecs.proto.Movement.Aspect
{
    using System;
    using Characteristics.Speed.Components;
    using Components;
    using Core.Components;
    using Gameplay.LevelProgress.Components;
    using Input.Components.Direction;
     
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class NavigationAspect : EcsAspect
    {
        public ProtoPool<NavMeshAgentComponent> Agent;
        public ProtoPool<RigidbodyComponent> Rigidbody;
        public ProtoPool<TransformComponent> Transform;
        public ProtoPool<TransformPositionComponent> Position;
        public ProtoPool<ActiveGameViewComponent> ActiveGameView;
        public ProtoPool<VelocityComponent> Velocity;
        public ProtoPool<SpeedComponent> Speed;
        public ProtoPool<AngularSpeedComponent> RotationSpeed;
        public ProtoPool<MovementStopRequest> NavMeshAgentStop;
        public ProtoPool<ImmobilityComponent> Immobility;
        public ProtoPool<DirectionInputEvent> Direction;
        public ProtoPool<StepMovementComponent> StepMovement;
        public ProtoPool<MovementPointRequest> MovementTargetPoint;
        public ProtoPool<ComePointComponent> ComePoint;
        public ProtoPool<InstantRotateComponent> InstantRotate;

        //requests
        public ProtoPool<RotateToPointSelfRequest> RotateTo;
        public ProtoPool<SetNavigationStatusSelfRequest> SetNavigationStatus;
        public ProtoPool<SetKinematicSelfRequest> SetKinematicStatus;
        


    }
}