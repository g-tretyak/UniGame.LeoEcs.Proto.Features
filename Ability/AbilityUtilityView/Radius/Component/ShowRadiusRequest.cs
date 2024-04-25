namespace unigame.ecs.proto.Ability.AbilityUtilityView.Radius.Component
{
    using Leopotam.EcsProto.QoL;
    using UnityEngine;

    public struct ShowRadiusRequest
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;

        public Transform Root;
        public GameObject Radius;
        
        public Vector3 Size;
    }
}