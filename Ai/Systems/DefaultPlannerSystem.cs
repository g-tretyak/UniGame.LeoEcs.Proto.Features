namespace unigame.ecs.proto.AI.Systems
{
    using System;
    using Components;
     
    using Service;
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class DefaultPlannerSystem : BasePlannerSystem<AiDefaultActionComponent>,IProtoInitSystem
    {
        [InlineProperty]
        [HideLabel]
        [SerializeField]
        private AiPlannerData _plannerData;

        private EcsFilter _filter;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world= systems.GetWorld();
            _filter = _world.Filter<AiAgentComponent>().End();
        }
        
        public override void Run()
        {
            var actionComponentPool = _world.GetPool<AiDefaultActionComponent>();
            
            foreach (var entity in _filter)
            {
                if(!IsPlannerEnabledForEntity(_world,entity))
                    continue;
                
                actionComponentPool.GetOrAddComponent<AiDefaultActionComponent>(entity);
                ApplyPlanningResult(systems,entity,_plannerData);
            }
        }
    }
}
