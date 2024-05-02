namespace UniGame.Ecs.Proto.AI.Systems
{
    using System;
    using System.Collections.Generic;
    using Components;
    using Configurations;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    /// <summary>
    /// Система удаляет для система экшенов их компоненты с данными,
    /// тем самым включая/выключая логику для сущности агента.
    /// </summary>
    [Serializable]
    public class AiUpdatePlanningActionsStatusSystem : IProtoRunSystem, IProtoInitSystem
    {
        private IReadOnlyList<AiActionData> _actionData;
        private EcsFilter _filter;
        private ProtoWorld _world;
        private IProtoSystems _systems;

        public AiUpdatePlanningActionsStatusSystem(IReadOnlyList<AiActionData> actionData)
        {
            _actionData = actionData;
        }

        
        public void Init(IProtoSystems systems)
        {
            _systems = systems;
            _world = systems.GetWorld();
            _filter = _world.Filter<AiAgentComponent>().End();
        }
        
        public void Run()
        {
            var agentComponentPool = _world.GetPool<AiAgentComponent>();

            foreach (var entity in _filter)
            {
                ref var agentComponent = ref agentComponentPool.Get(entity);
                var actionsActions = agentComponent.PlannedActions;
                var availableActions = agentComponent.PlannedActions;
                
                for (var i = 0; i < actionsActions.Length; i++)
                {
                    var actionEnabled = actionsActions[i] && availableActions[i];
                    var dataItem = _actionData[i];
                    var planner = dataItem.planner;

                    if (actionEnabled)
                        continue;
                    
                    planner.RemoveComponent(_systems,entity);
                }
            }
        }

    }
}
