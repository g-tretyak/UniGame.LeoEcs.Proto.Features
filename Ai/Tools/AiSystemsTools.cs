namespace unigame.ecs.proto.AI.Tools
{
    using Components;
     

    public static class AiSystemsTools
    {
        public static bool IsPlannerEnabledForEntity(ProtoWorld world, int entity, int plannerId)
        {
            var pool = world.GetPool<AiAgentComponent>();
            ref var aiAgentComponent = ref pool.Get(entity);
            var availableActions = aiAgentComponent.AvailableActions;
            return availableActions.Length > plannerId && availableActions[plannerId];
        }
    }
}
