namespace unigame.ecs.proto.Movement.Components
{
     

    public struct ImmobilityComponent : IProtoAutoReset<ImmobilityComponent>
    {
        public int BlockSourceCounter;
        
        public void AutoReset(ref ImmobilityComponent c)
        {
            c.BlockSourceCounter = 0;
        }
    }
}