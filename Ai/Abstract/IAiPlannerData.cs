namespace unigame.ecs.proto.AI.Abstract
{
    using Service;

    public interface IAiPlannerData
    {
        ref AiPlannerData PlannerData { get; }
    }
}