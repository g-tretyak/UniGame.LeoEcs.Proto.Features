namespace UniGame.Ecs.Proto.ViewControl.Components
{
    using Leopotam.EcsProto.QoL;
    using UnityEngine;

    public struct HideViewRequest
    {
        public ProtoPackedEntity Destination;

        public GameObject View;
    }
}