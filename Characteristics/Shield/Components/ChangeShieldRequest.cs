namespace unigame.ecs.proto.Characteristics.Shield.Components
{
    using Leopotam.EcsProto.QoL;


    public struct ChangeShieldRequest
    {
        public float Value;
        
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;
    }
}