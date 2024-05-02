namespace UniGame.Ecs.Proto.Input.Aspects
{
    using System;
    using Components;
    using Components.Direction;
    using LeoEcs.Bootstrap.Runtime.Abstract;
    using Leopotam.EcsProto;
    using Map.Component;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class InputAspect : EcsAspect
    {
        public ProtoPool<MapMatrixComponent> InputMapMatrix;
        public ProtoPool<UserInputTargetComponent> InputTarget;
        public ProtoPool<DirectionBlockComponent> DirectionBlock;
        
        //events
        public ProtoPool<DirectionRawInputEvent> DirectionRawInputEvent;
        public ProtoPool<DirectionInputEvent> DirectionInputEvent;
        public ProtoPool<BeginDirectionInputEvent> BeginDirectionInputEvent;
        public ProtoPool<EndDirectionInputEvent> EndDirectionInputEvent;
    }
}