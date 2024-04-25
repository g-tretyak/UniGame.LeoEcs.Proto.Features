namespace unigame.ecs.proto.ViewControl.Components
{
    using Leopotam.EcsProto.QoL;
    using UnityEngine;

    public struct HideViewRequest
    {
        public ProtoPackedEntity Destination;

        public GameObject View;
    }
}