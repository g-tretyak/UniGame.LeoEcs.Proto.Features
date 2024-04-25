namespace unigame.ecs.proto.Ability.SubFeatures.Effects.Behaviours
{
    using System;
    using System.Collections.Generic;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using UnityEngine;
    using UnityEngine.Serialization;

    [Serializable]
    public sealed class ApplyEffectsBehaviour : IAbilityBehaviour
    {
        [FormerlySerializedAs("_effects")] 
        [SerializeReference] 
        public List<IEffectConfiguration> effects = new List<IEffectConfiguration>();
        
        public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
        {
            var effectsPool = world.GetPool<EffectsComponent>();
            ref var effectsComponent = ref effectsPool.Add(abilityEntity);
            effectsComponent.Effects.AddRange(effects);
        }
    }
}