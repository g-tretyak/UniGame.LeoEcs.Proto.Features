namespace unigame.ecs.proto.TargetSelection
{
    using Leopotam.EcsProto;

    public class TargetSelectionData
    {
        public readonly static ProtoEntity EmptyResult = ProtoEntity.FromIdx(-1);
        public const int MaxTargets = 32;
        public const int MaxAgents = 64;
    }
}