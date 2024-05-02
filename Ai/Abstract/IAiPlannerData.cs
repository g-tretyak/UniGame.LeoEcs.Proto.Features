namespace UniGame.Ecs.Proto.AI.Abstract
{
    using Service;

    public interface IAiPlannerData
    {
        ref AiPlannerData PlannerData { get; }
    }
}