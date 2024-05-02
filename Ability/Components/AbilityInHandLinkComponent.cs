namespace UniGame.Ecs.Proto.Ability.Common.Components
{
    using System;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// Текущее умение в руке.
    /// </summary>
    [Serializable]
    public struct AbilityInHandLinkComponent
    {
        public ProtoPackedEntity AbilityEntity;
    }
}