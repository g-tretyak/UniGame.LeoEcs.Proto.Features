namespace unigame.ecs.proto.Map
{
    using Component;
     
    using UnityEngine;

    public static class MapHelper
    {
        public static Matrix4x4 GetMatrix(ProtoWorld world)
        {
            var filter = world.Filter<MapMatrixComponent>().End();
            var matrixPool = world.GetPool<MapMatrixComponent>();

            if(filter.GetEntitiesCount() == 0)
                return Matrix4x4.identity;
            
            var firstEntity = filter.GetRawEntities()[0];
            var matrixComponent = matrixPool.Get(firstEntity);

            return matrixComponent.Value;
        }
    }
}