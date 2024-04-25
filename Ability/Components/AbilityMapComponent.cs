namespace unigame.ecs.proto.Ability.Common.Components
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
        public static int AbilitiesSlotsCount = 5;
        
        [InlineProperty]
        [ListDrawerSettings]
        public List<ProtoPackedEntity> AbilityEntities;

        public void AutoReset(ref AbilityMapComponent c)
        {
            c.AbilityEntities ??= new List<ProtoPackedEntity>(AbilitiesSlotsCount);
            c.AbilityEntities.Clear();
            for (int i = 0; i < AbilitiesSlotsCount; i++)
            {
                if (i < c.AbilityEntities.Count)
                    c.AbilityEntities[i] = new ProtoPackedEntity();
                else
                    c.AbilityEntities.Add(new ProtoPackedEntity());
            }
        }
    }
}