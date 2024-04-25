namespace unigame.ecs.proto.Gameplay.Damage.Components
{
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;


    public struct MadeDamageEvent : IProtoAutoReset<MadeDamageEvent>
    {
        public float Value;
        public bool IsCritical;
        
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;
        
        public void AutoReset(ref MadeDamageEvent c)
        {
            c.Value = 0.0f;
            c.IsCritical = false;
        }
    }
}