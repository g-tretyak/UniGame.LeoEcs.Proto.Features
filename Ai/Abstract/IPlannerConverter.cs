using unigame.ecs.proto.AI.Configurations;

namespace unigame.ecs.proto.AI.Abstract
{
    using UniGame.LeoEcs.Converter.Runtime.Abstract;

    public interface IPlannerConverter : IEcsComponentConverter
    {
        AiAgentActionId Id { get; }
        
    }
}