namespace unigame.ecs.proto.Movement.Aspect
{
    using System;
    using Characteristics.Speed.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Game.Ecs.Core.Death.Components;
    using Gameplay.LevelProgress.Components;
    using Input.Components.Direction;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class NavigationAspect : EcsAspect
    {
        //filters
        public ProtoItExc AgentFilter = It
            .Chain<NavMeshAgentComponent>()
            .Exc<DisabledComponent>()
            .Exc<PrepareToDeathComponent>()
            .End();
        
        //components
        public ProtoPool<NavMeshAgentComponent> Agent;
        public ProtoPool<RigidbodyComponent> Rigidbody;
        public ProtoPool<TransformComponent> Transform;
        public ProtoPool<TransformPositionComponent> Position;
        public ProtoPool<ActiveGameViewComponent> ActiveGameView;
        public ProtoPool<VelocityComponent> Velocity;
        public ProtoPool<SpeedComponent> Speed;
        public ProtoPool<AngularSpeedComponent> RotationSpeed;
        public ProtoPool<ImmobilityComponent> Immobility;
        public ProtoPool<StepMovementComponent> StepMovement;
        public ProtoPool<ComePointComponent> ComePoint;
        public ProtoPool<InstantRotateComponent> InstantRotate;
        public ProtoPool<PrepareToDeathComponent> PrepareToDeath;
        public ProtoPool<DisabledComponent> Disabled;

        //requests
        public ProtoPool<MovementStopSelfRequest> NavMeshAgentStop;
        public ProtoPool<MovementPointSelfRequest> MovementTargetPoint;
        public ProtoPool<RotateToPointSelfRequest> RotateTo;
        public ProtoPool<SetNavigationStatusSelfRequest> SetNavigationStatus;
        public ProtoPool<SetKinematicSelfRequest> SetKinematicStatus;
        
        //events
        public ProtoPool<DirectionInputEvent> Direction;
        
    }
}