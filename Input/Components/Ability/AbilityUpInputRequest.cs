namespace unigame.ecs.proto.Input.Components.Ability
{
    using Leopotam.EcsProto;


    public struct AbilityUpInputRequest : IProtoAutoReset<AbilityUpInputRequest>
    {
        public int InputId;
        public float ActiveTime;
        public void AutoReset(ref AbilityUpInputRequest c)
        {
            c.ActiveTime = 0.0f;
        }
    }
}