namespace unigame.ecs.proto.AI.Abstract
{
     
    using Service;

    public interface IAiAction
    {
        AiActionResult Execute( EcsSystems systems,int entity);
    }
}