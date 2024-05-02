namespace UniGame.Ecs.Proto.Ability.AbilityUtilityView.Radius.Component
{
    using System.Collections.Generic;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UnityEngine;

    public struct RadiusViewStateComponent : IProtoAutoReset<RadiusViewStateComponent>
    {
        public Dictionary<ProtoPackedEntity, GameObject> RadiusViews;
        
        public void AutoReset(ref RadiusViewStateComponent c)
        {
            c.RadiusViews ??= new Dictionary<ProtoPackedEntity, GameObject>();
            c.RadiusViews.Clear();
        }
    }
}