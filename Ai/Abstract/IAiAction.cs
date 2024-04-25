namespace unigame.ecs.proto.AI.Abstract
{
    using Leopotam.EcsProto;
    using Service;

    public interface IAiAction
    {
        AiActionResult Execute( IProtoSystems systems,int entity);
    }
}