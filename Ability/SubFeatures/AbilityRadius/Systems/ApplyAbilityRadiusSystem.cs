namespace UniGame.Ecs.Proto.Ability.Common.Systems
{
    using Aspects;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using SubFeatures.AbilityAnimation.Aspects;
    using UniGame.Ecs.Proto.Characteristics.Attack.Components;
     
    using Tools;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// Add an empty target to an ability
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    public class ApplyAbilityRadiusSystem : IProtoRunSystem
    {
        private AbilityAspect _abilityTools;
        private ProtoWorld _world;
        private AbilityAspect _abilityAspect;
        private AbilityRadiusAspect _abilityRadiusAspect;
        
        private ProtoIt _radiusRequestFilter = It.Chain<ApplyAbilityRadiusRangeRequest>().End();

        public void Run()
        {
            foreach (var requestEntity in _radiusRequestFilter)
            {
                ref var request = ref _abilityRadiusAspect.ApplyRadiusRange.Get(requestEntity);
                
                if(!request.Target.Unpack(_world,out var targetEntity)) continue;
                
                var abilityEntity = _abilityTools.TryGetAbility(targetEntity, request.AbilitySlot);
                if((int)abilityEntity < 0) continue;
                
                if(!_abilityAspect.Radius.Has((ProtoEntity)abilityEntity)) continue;

                ref var abilityRadiusComponent = ref _abilityAspect.Radius.Get((ProtoEntity)abilityEntity);
                abilityRadiusComponent.Value = request.Value;

                _abilityRadiusAspect.ApplyRadiusRange.Del(requestEntity);
            }
        }
    }
}