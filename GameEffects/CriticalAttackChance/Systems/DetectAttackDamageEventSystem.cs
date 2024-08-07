namespace UniGame.Ecs.Proto.Gameplay.CriticalAttackChance.Systems
{
    using System;
    using Aspects;
    using Characteristics.CriticalChance.Aspects;
    using Damage.Aspects;
    using Damage.Components.Events;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
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
    public class DetectAttackDamageEventSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private CriticalAttackChanceAspect _criticalAttackChanceAspect;
        private CriticalChanceAspect _criticalChanceAspect;
        private DamageAspect _damageAspect;
        
        private ProtoIt _damageFilter = It
            .Chain<MadeDamageEvent>()
            .End();
        
        public void Run()
        {
            foreach (var entity in _damageFilter)
            {
                ref var eventComponent = ref _damageAspect.MadeDamage.Get(entity);
                if(!eventComponent.Source.Unpack(_world,out var sourceEntity))continue;
                
                if(!_criticalChanceAspect.CriticalChance.Has(sourceEntity))continue;

                _criticalAttackChanceAspect.Recalculate.GetOrAddComponent(sourceEntity);
            }
        }
    }
}