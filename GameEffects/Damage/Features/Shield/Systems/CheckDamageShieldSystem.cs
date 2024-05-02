namespace UniGame.Ecs.Proto.Gameplay.Damage.Systems
{
    using System;
    using Characteristics.Shield.Components;
    using Components.Request;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// reduce damage by shield value
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class CheckDamageShieldSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<ApplyDamageRequest> _requestPool;
        private ProtoPool<ChangeShieldRequest> _changeShieldPool;
        private ProtoPool<ShieldComponent> _shieldPool;

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

                if (!_shieldPool.Has(destinationEntity)) continue;
                
                ref var shield = ref _shieldPool.Get(destinationEntity);
                var shieldValue = shield.Value;
                var shieldDamage = Mathf.Min(shieldValue, request.Value);

                var shieldRequestEntity = _world.NewEntity();
                ref var shieldRequest = ref _changeShieldPool.Add(shieldRequestEntity);
                shieldRequest.Source = request.Source;
                shieldRequest.Destination = request.Destination;
                shieldRequest.Value = -shieldDamage;

                request.Value -= shieldDamage;
            }
        }
    }
}