namespace UniGame.Ecs.Proto.AI.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
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
        private IProtoSystems _systems;

        public void Init(IProtoSystems systems)
        {
            _systems = systems;
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
                ApplyPlanningResult(_systems,entity,_plannerData);
            }
        }
    }
}
