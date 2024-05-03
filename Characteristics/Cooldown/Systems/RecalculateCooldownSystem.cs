namespace UniGame.Ecs.Proto.Characteristics.Cooldown.Systems
{
    using System;
    using Characteristics;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Timer.Components;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    [Serializable]
    public sealed class RecalculateCooldownSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<CooldownComponent> cooldownPool;
        private ProtoPool<BaseCooldownComponent> baseCooldownPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<RecalculateCooldownSelfRequest>()
                .Inc<BaseCooldownComponent>()
                .Inc<CooldownComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var baseCooldown = ref baseCooldownPool.Get(entity);
                ref var cooldown = ref cooldownPool.Get(entity);

                cooldown.Value = baseCooldown.Modifications.Apply(baseCooldown.Value);
            }
        }
    }
}