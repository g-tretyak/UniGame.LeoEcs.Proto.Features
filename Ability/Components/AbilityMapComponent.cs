namespace UniGame.Ecs.Proto.Ability.Common.Components
{
    using System;
    using System.Collections.Generic;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Sirenix.OdinInspector;

    /// <summary>
    /// Компонент со ссылками на доступные умения у сущности.
    /// </summary>
    [Serializable]
    public struct AbilityMapComponent : IProtoAutoReset<AbilityMapComponent>
    {
        public List<ProtoPackedEntity> Abilities;

        public Dictionary<int, ProtoPackedEntity> Slots;

        public void AutoReset(ref AbilityMapComponent c)
        {
            c.Slots ??= new Dictionary<int, ProtoPackedEntity>();
            c.Abilities ??= new List<ProtoPackedEntity>();
            
            c.Slots.Clear();
            c.Abilities.Clear();
        }
    }
}