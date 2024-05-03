namespace UniGame.Ecs.Proto.Characteristics.Duration.Components
{
    using System.Collections.Generic;
    using Characteristics;
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