namespace unigame.ecs.proto.GameAi.MoveToTarget.Components
{
    using Game.Code.GameLayers.Category;
    using Unity.Mathematics;

    public struct MoveToPoiComponent
    {
        public float Priority;
        public float3 Position;
        public CategoryId CategoryId;
    }
}
