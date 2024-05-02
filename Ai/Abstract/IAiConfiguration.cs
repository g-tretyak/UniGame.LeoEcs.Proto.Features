namespace UniGame.Ecs.Proto.AI.Abstract
{
    using System.Collections.Generic;
    using Configurations;

    public interface IAiConfiguration
    {
        IReadOnlyList<AiActionData> AiActions { get; }
    }
}