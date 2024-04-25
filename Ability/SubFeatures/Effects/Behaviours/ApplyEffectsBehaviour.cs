namespace unigame.ecs.proto.Ability.SubFeatures.Effects.Behaviours
{
    using System;
    using System.Collections.Generic;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Game.Code.Configuration.Runtime.Effects.Abstract;
    using Leopotam.EcsProto;
    using proto.Effects.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UnityEngine.Serialization;

    [Serializable]
    public sealed class ApplyEffectsBehaviour : IAbilityBehaviour
    {
        [SerializeReference] 
        public List<IEffectConfiguration> effects = new();
        
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
        {
            var effectsPool = world.GetPool<EffectsComponent>();
            ref var effectsComponent = ref effectsPool.Add(abilityEntity);
            effectsComponent.Effects.AddRange(effects);
        }
    }
}