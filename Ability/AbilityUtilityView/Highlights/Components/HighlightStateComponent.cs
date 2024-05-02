namespace UniGame.Ecs.Proto.Ability.AbilityUtilityView.Highlights.Components
{
    using System.Collections.Generic;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UnityEngine;

    public struct HighlightStateComponent : IProtoAutoReset<HighlightStateComponent>
    {
        public Dictionary<ProtoPackedEntity, GameObject> Highlights;
        
        public void AutoReset(ref HighlightStateComponent c)
        {
            c.Highlights ??= new Dictionary<ProtoPackedEntity, GameObject>();
            c.Highlights.Clear();
        }
    }
}