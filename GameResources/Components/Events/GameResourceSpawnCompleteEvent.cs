namespace unigame.ecs.proto.GameResources.Components
{
    using System;
    using Leopotam.EcsProto.QoL;
    using Object = UnityEngine.Object;

    [Serializable]
    public struct GameResourceSpawnCompleteEvent
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity SpawnedEntity;
        public string ResourceId;
        public Object Resource;
    }
    
    
}