namespace unigame.ecs.proto.Animations.Components.Requests
{
    using System;
    using Game.Code.Animations;
    using Leopotam.EcsProto.QoL;
    using UnityEngine.Serialization;

    /// <summary>
    /// try play animation by link
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct CreateAnimationLinkSelfRequest
    {
        public ProtoPackedEntity Owner;
        [FormerlySerializedAs("PlayableDirectorEntity")] public ProtoPackedEntity Target;
        public AnimationLink Data;
    }
}