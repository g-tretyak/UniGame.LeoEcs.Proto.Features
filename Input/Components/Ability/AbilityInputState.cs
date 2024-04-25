namespace unigame.ecs.proto.Input.Components.Ability
{
     

    internal struct AbilityInputState : IProtoAutoReset<AbilityInputState>
    {
        public int InputId;
        public float ActiveTime;
        
        public void AutoReset(ref AbilityInputState c)
        {
            c.InputId = -1;
            c.ActiveTime = 0.0f;
        }
    }
}