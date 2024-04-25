namespace unigame.ecs.proto.Gameplay.Damage.Systems
{
    using System;
    using Components;
    using Components.Request;
    using Events;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using unigame.ecs.proto.Characteristics.Base.Components.Requests.OwnerRequests;
    using unigame.ecs.proto.Characteristics.Health.Components;
    using unigame.ecs.proto.Characteristics.Shield.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// apply damage to target
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class ApplyDamageSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<ApplyDamageRequest> _requestPool;
        private ProtoPool<ChangeCharacteristicBaseRequest<HealthComponent>> _changeHealthPool;
        private ProtoPool<ChangeShieldRequest> _changeShieldPool;
        private ProtoPool<ShieldComponent> _shieldPool;
        private ProtoPool<MadeDamageEvent> _madeDamagePool;
        private ProtoPool<CriticalDamageEvent> _criticalDamagePool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<ApplyDamageRequest>().End();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var request = ref _requestPool.Get(entity);
                if (!request.Destination.Unpack(_world, out var destinationEntity))
                    continue;

                var healthDamage = request.Value;
                
                var healthRequestEntity = _world.NewEntity();
                ref var healthRequest = ref _changeHealthPool.Add(healthRequestEntity);
                healthRequest.Source = request.Source;
                healthRequest.Target = request.Destination;
                healthRequest.Value = -healthDamage;

                request.Source.Unpack(_world, out var sourceEntity);
                
                var eventEntity = _world.NewEntity();
                ref var madeDamage = ref _madeDamagePool.Add(eventEntity);
                madeDamage.Value = request.Value;
                madeDamage.Source = request.Source;
                madeDamage.Destination = request.Destination;
                madeDamage.IsCritical = request.IsCritical;

                if (!request.IsCritical) continue;
                
                ref var criticalEventComponent = ref _criticalDamagePool.Add(eventEntity);
                criticalEventComponent.Value = request.Value;
                criticalEventComponent.Source = request.Source;
                criticalEventComponent.Destination = request.Destination;
            }
        }
    }
}