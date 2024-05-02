namespace UniGame.Ecs.Proto.Effects
{
    using System;
    using Components;
    using Data;
    using Game.Code.Configuration.Runtime.Effects;
    using Game.Code.Configuration.Runtime.Effects.Abstract;
    using Game.Ecs.Time.Service;
    using Leopotam.EcsProto;
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [Serializable]
    public abstract class EffectConfiguration : IEffectConfiguration
    {
        private const string SpawnParentKey = "spawn parent";
        
        [OnValueChanged("CheckViewLiveTime", InvokeOnInitialize = true)]
        [Min(-1.0f)]
        [SerializeField]
        public float duration;
        
        [Min(-1.0f)]
        [SerializeField]
        public float periodicity = -1.0f;
        
        [Min(0f)]
        [SerializeField]
        public float delay;
        
        [SerializeField]
        public TargetType targetType = TargetType.Target;
        
        public AssetReferenceGameObject view;
        
        [OnValueChanged("CheckViewLiveTime")]
        public bool trimToDuration;
        
        
        private void CheckViewLiveTime()
        {
            if (!trimToDuration) return;
            viewLifeTime = duration;
        }
        
        [HideIf("trimToDuration")]
        [Min(-1.0f)]
        [SerializeField]
        public float viewLifeTime;

        [TitleGroup(SpawnParentKey)]
        public bool spawnAtRoot;
        
        [TitleGroup(SpawnParentKey)]
        [SerializeField]
        [HideIf(nameof(spawnAtRoot))]
        public ViewInstanceType viewInstanceType = ViewInstanceType.Body;

        [TitleGroup(SpawnParentKey)]
        [ShowIf(nameof(spawnAtRoot))]
        public EffectRootId effectRoot;
        
        
        [Tooltip("Если true, то визуал эффекта привязывается к источнику. " +
                 "Т.е. то, что создало эффект. Умрёт источник - умрёт и эффект. Если не истекло время жизни.\n" +
                 "Если false, то визуал эффекта привязывается к цели. " +
                 "Т.е. тому, на кого наложили эффект. Умрёт цель - умрёт и эффект. Если не истекло время жизни.")]
        public bool attachToSource;

        public TargetType TargetType => targetType;

        public void ComposeEntity(ProtoWorld world, ProtoEntity effectEntity)
        {
            var delayedPool = world.GetPool<DelayedEffectComponent>();
            if (delay > 0f && !delayedPool.Has(effectEntity))
            {
                ref var delayed = ref delayedPool.Add(effectEntity);
                delayed.Delay = delay;
                delayed.LastApplyingTime = GameTime.Time;
                delayed.Configuration = this;
                return;
            }
            
            var durationPool = world.GetPool<EffectDurationComponent>();
            ref var durationComponent = ref durationPool.Add(effectEntity);
            durationComponent.Duration = this.duration;
            durationComponent.CreatingTime = Time.time;

            var periodicityPool = world.GetPool<EffectPeriodicityComponent>();
            ref var periodicityComponent = ref periodicityPool.Add(effectEntity);
            periodicityComponent.Periodicity = this.periodicity;
            
            var isValidEffectView = view != null && view.RuntimeKeyIsValid();
            if (isValidEffectView)
            {
                ref var effectViewComponent = ref world.AddComponent<EffectViewDataComponent>(effectEntity);
                effectViewComponent.View = view;
                effectViewComponent.LifeTime = viewLifeTime;
                effectViewComponent.ViewInstanceType = viewInstanceType;
                effectViewComponent.AttachToSource = attachToSource;
                effectViewComponent.UseEffectRoot = spawnAtRoot;
                effectViewComponent.EffectRoot = effectRoot;
            }

            if (spawnAtRoot)
            {
                ref var rootTargetComponent = ref world.AddComponent<EffectRootIdComponent>(effectEntity);
                rootTargetComponent.Value = effectRoot;
            }

            Compose(world, effectEntity);
        }

        protected abstract void Compose(ProtoWorld world, ProtoEntity effectEntity);
    }
}