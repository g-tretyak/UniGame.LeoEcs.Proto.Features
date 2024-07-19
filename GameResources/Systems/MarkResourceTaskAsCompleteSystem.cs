namespace UniGame.Ecs.Proto.GameResources.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class MarkResourceTaskAsCompleteSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private GameResourceTaskAspect _taskAspect;
        
        private ProtoItExc _filter = It
            .Chain<GameResourceTaskCompleteComponent>()
            .Exc<GameResourceTaskCompleteSelfEvent>()
            .End();
        
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