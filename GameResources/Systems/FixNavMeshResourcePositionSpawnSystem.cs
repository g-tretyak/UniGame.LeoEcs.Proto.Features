namespace UniGame.Ecs.Proto.GameResources.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UnityEngine.AI;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class FixNavMeshResourcePositionSpawnSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private GameResourceTaskAspect _taskAspect;
        
        private ProtoIt _filter = It
            .Chain<GameResourceResultComponent>()
            .Inc<GameObjectComponent>()
            .End();
        
        
        public void Run()
        {
            //mark game resource task as complete
            foreach (var entity in _filter)
            {
                ref var gameObjectComponent = ref _taskAspect.GameObject.Get(entity);
                ref var positionComponent = ref _taskAspect.Position.Get(entity);

                var gameObject = gameObjectComponent.Value;
                var navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
                var isNavMeshAgent = navMeshAgent;
                var targetPosition = positionComponent.Value;
                
                //fix spawn object navmesh position
                if (!isNavMeshAgent) continue;
                
                var isCorrect = NavMesh.SamplePosition(targetPosition,out var hit,100f,NavMesh.AllAreas);
                targetPosition = isCorrect ? hit.position : targetPosition;
                positionComponent.Value = targetPosition;
            }
        }
    }
}