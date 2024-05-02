namespace UniGame.Ecs.Proto.ViewControl.Components
{
    using System.Collections.Generic;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UnityEngine;

    internal struct ViewDataComponent : IProtoAutoReset<ViewDataComponent>
    {
        public Dictionary<GameObject, ProtoPackedEntity> Views;

        public void AutoReset(ref ViewDataComponent c)
        {
            c.Views ??= new Dictionary<GameObject, ProtoPackedEntity>();
            c.Views.Clear();
        }
    }
}