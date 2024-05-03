namespace UniGame.Ecs.Proto.GameEffects.ModificationEffect
{
    using System;
    using System.Collections.Generic;
    using Characteristics;
    using Components;
    using Effects;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class ModificationEffectConfiguration : EffectConfiguration
    {
        [SerializeReference]
        public List<ModificationHandler> modificationHandlers = new List<ModificationHandler>();
        
        protected override void Compose(ProtoWorld world, ProtoEntity effectEntity)
        {
            var modificationPool = world.GetPool<ModificationEffectComponent>();
            ref var modification = ref modificationPool.Add(effectEntity);
            
            var handlers = modification.ModificationHandlers;
            handlers.AddRange(modificationHandlers);
        }
    }
}