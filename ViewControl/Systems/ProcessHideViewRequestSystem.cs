namespace UniGame.Ecs.Proto.ViewControl.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class ProcessHideViewRequestSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world= systems.GetWorld();
            _filter = _world.Filter<HideViewRequest>().End();
        }
        
        public void Run()
        {

            var requestPool = _world.GetPool<HideViewRequest>();
            var viewDataPool = _world.GetPool<ViewDataComponent>();
            var viewInstancePool = _world.GetPool<ViewInstanceComponent>();

            foreach (var entity in _filter)
            {
                ref var request = ref requestPool.Get(entity);
                if(!request.Destination.Unpack(_world, out var destinationEntity))
                    continue;
                
                if(!viewDataPool.Has(destinationEntity))
                    continue;

                ref var viewData = ref viewDataPool.Get(destinationEntity);
                if(!viewData.Views.TryGetValue(request.View, out var viewPackedEntity))
                    continue;

                if(!viewPackedEntity.Unpack(_world, out var viewEntity))
                    continue;

                ref var viewInstance = ref viewInstancePool.Get(viewEntity);
                viewInstance.Count--;

                if (viewInstance.Count > 0)
                    continue;

                viewData.Views.Remove(request.View);
                
                Object.Destroy(viewInstance.ViewInstance);
                _world.DelEntity(viewEntity);
            }
        }
    }
}