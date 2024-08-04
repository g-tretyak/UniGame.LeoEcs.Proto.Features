namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Tools;
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
    public sealed class SetInHandAbilityRequestSystem : IProtoRunSystem
    {
        private AbilityAspect _abilityAspect;
        private ProtoWorld _world;
        
        private ProtoPool<SetInHandAbilitySelfRequest> _setInHandPool;
        private ProtoPool<ActiveAbilityComponent> _activePool;

        private ProtoIt _filter = It
            .Chain<SetInHandAbilitySelfRequest>()
            .Inc<AbilityInHandLinkComponent>()
            .End();

        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var setInHand = ref _setInHandPool.Get(entity);
                if(!setInHand.Value.Unpack(_world,out var nextAbilityEntity))
                    continue;

                if(!_activePool.Has(nextAbilityEntity)) continue;
                
                _abilityAspect.ChangeInHandAbility(entity, nextAbilityEntity);
            }
        }
    }
}