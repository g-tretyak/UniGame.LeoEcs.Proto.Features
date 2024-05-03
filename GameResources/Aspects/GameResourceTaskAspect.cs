namespace UniGame.Ecs.Proto.GameResources.Aspects
{
    using System;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcsLite.LeoEcs.Shared.Components;

    [Serializable]
    public class GameResourceTaskAspect : EcsAspect
    {
        public ProtoPool<GameResourceHandleComponent> Handle;
        public ProtoPool<GameResourceTaskComponent> Task;
        public ProtoPool<GameResourceResultComponent> Result;
        public ProtoPool<TransformParentComponent> Parent;
        public ProtoPool<ParentEntityComponent> ParentEntity;
        public ProtoPool<PositionComponent> Position;
        public ProtoPool<RotationComponent> Rotation;
        public ProtoPool<ScaleComponent> Scale;
        public ProtoPool<EntityComponent> Target;
        
        //optional
        public ProtoPool<GameObjectComponent> GameObject;
        public ProtoPool<GameResourceTaskCompleteComponent> Complete;
        
        //event
        public ProtoPool<GameResourceTaskCompleteSelfEvent> CompleteEvent;
        
        //requests
        public ProtoPool<GameResourceSpawnRequest> SpawnRequest;
    }
}