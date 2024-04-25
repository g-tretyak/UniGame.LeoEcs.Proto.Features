namespace unigame.ecs.proto.GameAi.MoveToTarget.Systems
{
    using System.Linq;
    using Components;
    using Core.Death.Components;
     

    public sealed class ResetPoiSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<MoveToPoiGoalsComponent>()
                .Inc<DisabledEvent>()
                .End();
        }
        
        public void Run()
        {
            var goalsPool = _world.GetPool<MoveToPoiGoalsComponent>();

            foreach (var entity in _filter)
            {
                ref var goals = ref goalsPool.Get(entity);
                var keys = goals.GoalsLinks.Keys.ToArray();
                foreach (var key in keys)
                {
                    var data = goals.GoalsLinks[key];
                    data.Complete = false;
                    goals.GoalsLinks[key] = data;
                }
            }
        }
    }
}