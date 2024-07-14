namespace UniGame.Ecs.Proto.Ability.Common.Components
{
    using Leopotam.EcsProto;


    /// <summary>
    /// Компонент состояния оценки умения.
    /// </summary>
    public struct AbilityEvaluationComponent : IProtoAutoReset<AbilityEvaluationComponent>
    {
        public float EvaluateTime;
        
        public void AutoReset(ref AbilityEvaluationComponent c)
        {
            c.EvaluateTime = 0.0f;
        }
    }
}