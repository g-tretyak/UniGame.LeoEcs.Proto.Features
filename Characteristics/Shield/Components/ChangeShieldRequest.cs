namespace UniGame.Ecs.Proto.Characteristics.Shield.Components
{
    using Leopotam.EcsProto.QoL;


    public struct ChangeShieldRequest
    {
        public float Value;
        
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;
    }
}