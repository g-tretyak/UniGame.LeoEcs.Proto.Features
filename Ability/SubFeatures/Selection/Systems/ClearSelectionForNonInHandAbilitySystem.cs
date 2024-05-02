namespace UniGame.Ecs.Proto.Ability.SubFeatures.Selection.Systems
{
    using System;
    using Common.Components;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;


    public sealed class ClearSelectionForNonInHandAbilitySystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<SelectedTargetsComponent>()
                .Exc<AbilityInHandComponent>()
                .End();
        }
        
        public void Run()
        {
            var targetsPool = _world.GetPool<SelectedTargetsComponent>();

            foreach (var entity in _filter)
            {
                ref var targets = ref targetsPool.Get(entity);
                targets.SetEntities(Array.Empty<ProtoPackedEntity>(),0);
            }
        }
    }
}