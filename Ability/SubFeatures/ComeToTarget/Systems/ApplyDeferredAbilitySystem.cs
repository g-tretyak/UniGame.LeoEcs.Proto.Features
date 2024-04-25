namespace unigame.ecs.proto.Ability.SubFeatures.ComeToTarget.Systems
{
    using System;
    using Common.Components;
    using Components;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ApplyDeferredAbilitySystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<DeferredAbilityComponent> _deferredPool;
        private ProtoPool<AbilityInHandComponent> _inHandPool;
        private ProtoPool<AbilityValidationSelfRequest> _requestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<DeferredAbilityComponent>()
                .Inc<OwnerComponent>()
                .Exc<UpdateComePointComponent>()
                .End();
        }
        
        public void Run()
        {
            

            foreach (var entity in _filter)
            {
                _deferredPool.Del(entity);

                if(!_inHandPool.Has(entity))
                    continue;
                
                _requestPool.GetOrAddComponent(entity);
            }
        }
    }
}