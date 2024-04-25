namespace unigame.ecs.proto.GameAi.ActivateAbility
{
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// ai ability selection event
    /// </summary>
    public struct AbilityAiActionTargetComponent
    {
        public int AbilityCellId;
        public ProtoPackedEntity Ability;
        public ProtoPackedEntity AbilityTarget;
    }

}