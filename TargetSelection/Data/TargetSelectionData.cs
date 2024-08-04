namespace UniGame.Ecs.Proto.TargetSelection
{
    using Leopotam.EcsProto;

    public class TargetSelectionData
    {
        public static readonly ProtoEntity EmptyResult = (ProtoEntity)(-1);
        public const int MaxTargets = 32;
        public const int MaxAgents = 64;
    }
}