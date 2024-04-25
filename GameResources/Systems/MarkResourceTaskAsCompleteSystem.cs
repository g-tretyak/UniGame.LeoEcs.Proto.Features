namespace unigame.ecs.proto.GameResources.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class MarkResourceTaskAsCompleteSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private GameResourceTaskAspect _taskAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<GameResourceTaskCompleteComponent>()
                .Exc<GameResourceTaskCompleteSelfEvent>()
                .End();
        }
        
        public void Run()
        {
            //mark game resource task as complete
            foreach (var entity in _filter)
            {
                ref var completeComponent = ref _taskAspect.CompleteEvent.Add(entity);
            }
        }
    }
}