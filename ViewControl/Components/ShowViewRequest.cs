namespace UniGame.Ecs.Proto.ViewControl.Components
{
    using Leopotam.EcsProto.QoL;
    using UnityEngine;

    public struct ShowViewRequest
    {
        public ProtoPackedEntity Destination;

        public GameObject View;
        
        public Transform Root;
        public Vector3 Size;
    }
}