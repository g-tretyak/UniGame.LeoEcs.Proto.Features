namespace Game.Code.Ai.ActivateAbility
{
    using System;
    using Leopotam.EcsProto.QoL;


    [Serializable]
    public struct ActivateAbilityActionComponent
    {
        public int AbilityCellId;
        public ProtoPackedEntity Target;
        public ProtoPackedEntity Ability;
    }
}
