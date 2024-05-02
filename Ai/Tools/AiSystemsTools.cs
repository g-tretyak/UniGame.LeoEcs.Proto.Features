namespace UniGame.Ecs.Proto.AI.Tools
{
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;


    public static class AiSystemsTools
    {
        public static bool IsPlannerEnabledForEntity(ProtoWorld world, ProtoEntity entity, int plannerId)
        {
            var pool = world.GetPool<AiAgentComponent>();
            ref var aiAgentComponent = ref pool.Get(entity);
            var availableActions = aiAgentComponent.AvailableActions;
            return availableActions.Length > plannerId && availableActions[plannerId];
        }
    }
}
