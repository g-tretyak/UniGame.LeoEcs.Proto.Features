namespace unigame.ecs.proto.Core.Components
{
    using System;
    using Game.Code.Animations;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// link to animation entity
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct AnimationLinkComponent
    {
        public ProtoPackedEntity Value;
    }
    
    [Serializable]
    public struct AnimationDataLinkComponent
    {
        public AnimationLink AnimationLink;
    }
    

}