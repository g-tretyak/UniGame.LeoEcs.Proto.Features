namespace UniGame.Ecs.Proto.Gameplay.CriticalAttackChance.Systems
{
    using System;
    using Aspects;
    using Characteristics.CriticalChance.Aspects;
    using Components.Requests;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.Ecs.Proto.Characteristics.CriticalChance.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using Random = UnityEngine.Random;

    /// <summary>
    /// add ot remove from character CriticalAttackMarkerComponent as a critical attack marker
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class RecalculateCriticalChanceSystem : IProtoRunSystem
    {
        private ProtoWorld _world;
        private CriticalAttackChanceAspect _criticalAttackChanceAspect;
        private CriticalChanceAspect _criticalChanceAspect;

        private ProtoIt _damageFilter = It
            .Chain<RecalculateCriticalChanceSelfRequest>()
            .Inc<CriticalChanceComponent>()
            .End();

        public void Run()
        {
            foreach (var sourceEntity in _damageFilter)
            {
                _criticalAttackChanceAspect.CriticalAttackMarker.TryRemove(sourceEntity);
                _criticalAttackChanceAspect.Recalculate.TryRemove(sourceEntity);

                ref var criticalChance = ref _criticalChanceAspect.CriticalChance.Get(sourceEntity);
                var isCritical = Random.Range(0.0f, 100.0f) < criticalChance.Value;

                if (!isCritical) continue;

                _criticalAttackChanceAspect.CriticalAttackMarker.GetOrAddComponent(sourceEntity);
            }
        }
    }
}