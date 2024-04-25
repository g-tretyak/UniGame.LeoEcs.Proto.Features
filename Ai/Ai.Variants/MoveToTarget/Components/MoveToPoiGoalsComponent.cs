namespace unigame.ecs.proto.GameAi.MoveToTarget.Components
{
    using System.Collections.Generic;
    using Data;
     

    public struct MoveToPoiGoalsComponent : IProtoAutoReset<MoveToPoiGoalsComponent>
    {
        public Dictionary<int, MoveToGoalData> GoalsLinks;

        public void AutoReset(ref MoveToPoiGoalsComponent c)
        {
            c.GoalsLinks ??= new Dictionary<int, MoveToGoalData>(8);
            c.GoalsLinks.Clear();
        }
    }
}