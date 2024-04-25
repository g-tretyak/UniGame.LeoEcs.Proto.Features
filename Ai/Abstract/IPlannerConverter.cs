using unigame.ecs.proto.AI.Configurations;
using UniGame.LeoEcs.Converter.Runtime.Abstract;

namespace unigame.ecs.proto.AI.Abstract
{
    public interface IPlannerConverter : IEcsComponentConverter
    {
        AiAgentActionId Id { get; }
        
    }
}