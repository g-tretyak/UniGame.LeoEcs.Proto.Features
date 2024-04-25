namespace unigame.ecs.proto.GameAi.MoveToTarget.Converters
{
    using System;
    using AI.Abstract;
    using Components;

    [Serializable]
    public class MoveByPoiConverter : ComponentPlannerConverter<MoveByPoiComponent>, IMoveByConverter
    {
        
    }
}