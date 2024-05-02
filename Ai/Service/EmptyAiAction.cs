namespace UniGame.Ecs.Proto.AI.Service
{
    using System;
    using Abstract;
    using Leopotam.EcsProto;


    [Serializable]
    public sealed class EmptyAiAction : IAiAction
    {
        public static EmptyAiAction EmptyAction = new EmptyAiAction();
        
        public static AiActionResult EmptyAiActionResult = new AiActionResult();

        public AiActionResult Execute(IProtoSystems systems, int entity)
        {
            return new AiActionResult() { ActionStatus = AiActionStatus.Complete };
        }
    }
}