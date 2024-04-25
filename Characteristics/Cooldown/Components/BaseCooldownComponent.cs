namespace unigame.ecs.proto.Characteristics.Cooldown.Components
{
    using System.Collections.Generic;
    using Base.Modification;
    using Leopotam.EcsProto;


    public struct BaseCooldownComponent : IProtoAutoReset<BaseCooldownComponent>
    {
        public float Value;
        
        public List<Modification> Modifications;
        
        public void AutoReset(ref BaseCooldownComponent c)
        {
            c.Modifications ??= new List<Modification>();
            c.Modifications.Clear();
        }
    }
}