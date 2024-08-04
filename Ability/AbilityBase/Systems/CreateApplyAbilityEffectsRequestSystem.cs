namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class CreateApplyAbilityEffectsRequestSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<AbilityEffectMilestonesComponent> _milestonesPool;
        private ProtoPool<AbilityEvaluationComponent> _evaluationPool;
        private ProtoPool<ApplyAbilityEffectsSelfRequest> _requestPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<AbilityEffectMilestonesComponent>()
                .Inc<AbilityEvaluationComponent>()
                .Inc<AbilityUsingComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var milestones = ref _milestonesPool.Get(entity);
                ref var evaluation = ref _evaluationPool.Get(entity);

                var evaluationTime = evaluation.EvaluateTime;
                for (var i = 0; i < milestones.Milestones.Length; i++)
                {
                    ref var milestone = ref milestones.Milestones[i];
                    if (milestone.IsApplied)
                        continue;

                    if (milestone.Time > evaluationTime && !Mathf.Approximately(milestone.Time, evaluationTime))
                        continue;

                    milestone.IsApplied = true;
                    _requestPool.Add(entity);
                }
            }
        }
    }
}