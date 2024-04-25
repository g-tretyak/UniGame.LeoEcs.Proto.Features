namespace unigame.ecs.proto.Map
{
    using Component;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public static class MapHelper
    {
        public static Matrix4x4 GetMatrix(ProtoWorld world)
        {
            var filter = world.Filter<MapMatrixComponent>().End();
            var matrixPool = world.GetPool<MapMatrixComponent>();

            if(filter.First() < 0) return Matrix4x4.identity;
            
            var firstEntity = (ProtoEntity)filter.First();
            var matrixComponent = matrixPool.Get(firstEntity);

            return matrixComponent.Value;
        }
    }
}