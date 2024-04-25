namespace unigame.ecs.proto.GameResources.Components
{
    using Leopotam.EcsProto.QoL;


    public struct GameResourceSourceLinkComponent
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity SpawnedEntity;
    }
}