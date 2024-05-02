namespace UniGame.Ecs.Proto.AI
{
    using Abstract;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UnityEngine;

    public class AiPlannerFeature : ScriptableObject
    {
        protected int _id;

        public int Id => _id;
        
        public async UniTask Initialize(int id,IProtoSystems ecsSystems)
        {
            _id = id;

            await OnInitialize(id, ecsSystems);
        }
        
        protected virtual UniTask OnInitialize(int id, IProtoSystems systems) => UniTask.CompletedTask;
    }
    
    public class AiPlannerFeature<TPlanner> : ScriptableObject
        where TPlanner : IAiPlannerSystem
    {
        #region inspector

        public TPlanner plannerSystem;

        #endregion
        
        protected int _id;

        public int Id => _id;
        
        public async UniTask Initialize(int id,IProtoSystems ecsSystems)
        {
            _id = id;

            await OnInitialize(id, ecsSystems);
        }
        
        protected virtual UniTask OnInitialize(int id, IProtoSystems systems) => UniTask.CompletedTask;
    }
}