namespace unigame.ecs.proto.Characteristics.Duration.Components
{
    using System.Collections.Generic;
    using Base.Modification;
    using Leopotam.EcsProto;


    public struct BaseDurationComponent : IProtoAutoReset<BaseDurationComponent>
    {
        public float Value;
        
        public List<Modification> Modifications;
        
        public void AutoReset(ref BaseDurationComponent c)
        {
            c.Modifications ??= new List<Modification>();
        }
    }
}