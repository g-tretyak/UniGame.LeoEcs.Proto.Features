namespace UniGame.Ecs.Proto.GameResources.Systems
{
    using System;
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
    public class DestroyCompletedResourceTaskSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        
        private ProtoIt _filter = It
            .Chain<GameResourceTaskCompleteSelfEvent>()
            .Inc<GameResourceTaskCompleteComponent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _filter)
                _world.DelEntity(entity);
        }
    }
}