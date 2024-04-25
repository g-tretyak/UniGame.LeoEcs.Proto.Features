namespace unigame.ecs.proto.GameAi.MoveToTarget.Systems
{
    using AI.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using unigame.ecs.proto.GameAi.MoveToTarget.Components;
    using UniGame.LeoEcs.Shared.Extensions;


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