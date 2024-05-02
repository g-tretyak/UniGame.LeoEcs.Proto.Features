using UniGame.Ecs.Proto.AI.Configurations;

namespace UniGame.Ecs.Proto.AI.Abstract
{
    using UniGame.LeoEcs.Converter.Runtime.Abstract;

    public interface IPlannerConverter : IEcsComponentConverter
    {
        AiAgentActionId Id { get; }
        
    }
}