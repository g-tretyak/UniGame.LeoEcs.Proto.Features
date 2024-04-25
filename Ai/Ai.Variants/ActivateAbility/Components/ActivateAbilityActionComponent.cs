namespace Game.Code.Ai.ActivateAbility
{
    using System;
     

    [Serializable]
    public struct ActivateAbilityActionComponent
    {
        public int AbilityCellId;
        public ProtoPackedEntity Target;
        public ProtoPackedEntity Ability;
    }
}
