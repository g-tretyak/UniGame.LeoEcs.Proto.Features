namespace UniGame.Ecs.Proto.GameResources.Components
{
    using Leopotam.EcsProto.QoL;


    public struct GameResourceSourceLinkComponent
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity SpawnedEntity;
    }
}