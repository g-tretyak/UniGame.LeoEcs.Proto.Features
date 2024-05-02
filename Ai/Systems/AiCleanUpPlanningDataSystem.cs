namespace UniGame.Ecs.Proto.AI.Systems
{
    using System;
    using System.Collections.Generic;
    using Components;
    using Configurations;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Service;
    using UniGame.LeoEcs.Shared.Extensions;


    [Serializable]
    public class AiCleanUpPlanningDataSystem : IProtoRunSystem, IProtoInitSystem
    {
        private IReadOnlyList<AiActionData> _actionData;
        private EcsFilter _filter;
        private ProtoWorld _world;
        private IProtoSystems _systems;
        
        public void Init(IProtoSystems systems)
        {
            _systems = systems;
            _world = systems.GetWorld();
            _filter = _world.Filter<AiAgentComponent>().End();
        }
        
        public AiCleanUpPlanningDataSystem(IReadOnlyList<AiActionData> actionData)
        {
            _actionData = actionData;
        }
    
        public void Run()
        {
            var agentComponentPool = _world.GetPool<AiAgentComponent>();
            var selfControllerAgents = _world.GetPool<AiAgentSelfControlComponent>();
        
            foreach (var entity in _filter)
            {
                ref var agentComponent = ref agentComponentPool.Get(entity);
                var actionsMap = agentComponent.PlannedActions;
                
                for (var i = 0; i < actionsMap.Length; i++)
                {
                    //reset priority
                    ref var data = ref agentComponent.PlannerData[i];
                    data.Priority = AiConstants.PriorityNever;
                
                    //update action status
                    var actions = agentComponent.PlannedActions;
                    var actionStatus = actions[i];
                    var selfController = selfControllerAgents.Has(entity);
                    agentComponent.PlannedActions[i] = selfController && actionStatus;
                
                    //remove ai system components
                    var planner = _actionData[i].planner;
                    planner.RemoveComponent(_systems,entity);
                }
            }
        }

    }
}
