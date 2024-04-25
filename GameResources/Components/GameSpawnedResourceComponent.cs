namespace unigame.ecs.proto.GameResources.Components
{
    using System;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// game resource component marker
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct GameSpawnedResourceComponent
    {
        public ProtoPackedEntity Source;
    }
}