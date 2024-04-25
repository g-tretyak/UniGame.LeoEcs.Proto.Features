namespace unigame.ecs.proto.AI.Abstract
{
    using Cysharp.Threading.Tasks;
     
    using Service;

    public interface IAiPlannerSystem : IAiPlannerSwitched
    {
        public UniTask Initialize(int id,IProtoSystems ecsSystems);
       
        void ApplyPlanningResult(IProtoSystems systems, int entity, AiPlannerData data);
    }

    public interface IAiPlannerSwitched
    {
        void RemoveComponent(IProtoSystems systems, int entity);
    }
    
}