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
        [InlineProperty]
        [ListDrawerSettings]
        public List<ProtoPackedEntity> Abilities;

        public void AutoReset(ref AbilityMapComponent c)
        {
            c.Abilities ??= new List<ProtoPackedEntity>();
            c.Abilities.Clear();
        }
    }
}