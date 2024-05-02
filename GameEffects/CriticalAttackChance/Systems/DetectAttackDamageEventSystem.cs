namespace UniGame.Ecs.Proto.Gameplay.CriticalAttackChance.Systems
{
    using System;
    using Damage.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.Ecs.Proto.Characteristics.CriticalChance.Components;
     
    using Requests;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// recalculate is next attack critical or not
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class DetectAttackDamageEventSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _damageFilter;

        private ProtoPool<MadeDamageEvent> _damagePool;
        private ProtoPool<CriticalChanceComponent> _criticalComponent;
        private ProtoPool<RecalculateCriticalChanceSelfRequest> _recalculaltePool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _damageFilter = _world
                .Filter<MadeDamageEvent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _damageFilter)
            {
                ref var eventComponent = ref _damagePool.Get(entity);
                if(!eventComponent.Source.Unpack(_world,out var sourceEntity))continue;
                
                if(!_criticalComponent.Has(sourceEntity))continue;

                _recalculaltePool.GetOrAddComponent(sourceEntity);
            }
        }
    }
}