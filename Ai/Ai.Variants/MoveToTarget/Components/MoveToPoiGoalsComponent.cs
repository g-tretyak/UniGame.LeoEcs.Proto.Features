namespace UniGame.Ecs.Proto.GameAi.MoveToTarget.Components
{
    using System.Collections.Generic;
    using Data;
    using Leopotam.EcsProto;


    public struct MoveToPoiGoalsComponent : IProtoAutoReset<MoveToPoiGoalsComponent>
    {
        public Dictionary<ProtoEntity, MoveToGoalData> GoalsLinks;

        public void AutoReset(ref MoveToPoiGoalsComponent c)
        {
            c.GoalsLinks ??= new Dictionary<ProtoEntity, MoveToGoalData>(8);
            c.GoalsLinks.Clear();
        }
    }
}