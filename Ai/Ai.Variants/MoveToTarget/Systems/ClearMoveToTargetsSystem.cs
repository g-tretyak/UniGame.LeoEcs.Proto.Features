namespace unigame.ecs.proto.GameAi.MoveToTarget.Systems
{
    using unigame.ecs.proto.AI.Components;
    using unigame.ecs.proto.GameAi.MoveToTarget.Components;
     

    public class ClearMoveToTargetsSystem : IProtoRunSystem,IProtoInitSystem
    {
        
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<AiAgentComponent>()
                .Inc<MoveToGoalComponent>()
                .Inc<MoveToTargetPlannerComponent>()
                .End();
        }
        
        public void Run()
        {
            var goalPool = _world.GetPool<MoveToGoalComponent>();

            foreach (var entity in _filter)
            {
                ref var goalComponent = ref goalPool.Get(entity);
                goalComponent.Goals.Clear();
            }
        }
    }
}