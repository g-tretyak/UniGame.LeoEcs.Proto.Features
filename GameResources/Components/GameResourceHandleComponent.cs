namespace unigame.ecs.proto.GameResources.Components
{
    using System;
    using Leopotam.EcsProto.QoL;
    using UnityEngine.Serialization;

    [Serializable]
    public struct GameResourceHandleComponent
    {
        /// <summary>
        /// источник реквеста
        /// </summary>
        [FormerlySerializedAs("RequestOwner")] public ProtoPackedEntity Source;
        
        /// <summary>
        /// Владелец ресурса. Может быть пустым
        /// </summary>
        [FormerlySerializedAs("ResourceOwner")] public ProtoPackedEntity Owner;

        /// <summary>
        /// адрес ресурса
        /// </summary>
        public string Resource;
    }
    
    
    [Serializable]
    public struct GameResourceHandleComponent<TAsset>
    {
        /// <summary>
        /// источник реквеста
        /// </summary>
        public ProtoPackedEntity RequestOwner;
        
        /// <summary>
        /// Владелец ресурса. Может быть пустым
        /// </summary>
        public ProtoPackedEntity ResourceOwner;

        /// <summary>
        /// адрес ресурса
        /// </summary>
        public string Resource;
    }
}
