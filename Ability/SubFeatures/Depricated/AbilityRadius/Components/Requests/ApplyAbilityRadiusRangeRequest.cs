namespace UniGame.Ecs.Proto.Characteristics.Attack.Components
{
    using System;
    using Leopotam.EcsProto.QoL;


    [Serializable]
    public struct ApplyAbilityRadiusRangeRequest
    {
        public ProtoPackedEntity Target;
        public float Value;
        public int AbilitySlot;
    }
}