namespace unigame.ecs.proto.Effects.Components
{
    using System.Collections.Generic;
    using Game.Code.Configuration.Runtime.Effects.Abstract;
    using Leopotam.EcsProto;


    public struct EffectsComponent : IProtoAutoReset<EffectsComponent>
    {
        public List<IEffectConfiguration> Effects;
        
        public void AutoReset(ref EffectsComponent c)
        {
            c.Effects ??= new List<IEffectConfiguration>();
            c.Effects.Clear();
        }
    }
}