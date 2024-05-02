using System.Collections.Generic;
using UniGame.Ecs.Proto.GameEffects.ModificationEffect.Components;
using Sirenix.OdinInspector;
using UniGame.LeoEcs.Shared.Extensions;
using UnityEngine;

namespace UniGame.Ecs.Proto.Characteristics.Converters
{
    using System;
    using Base.Modification;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    
    /// <summary>
    /// create ModificationsComponents and add it to entity
    /// </summary>
    [Serializable]
    public class ModificationsConverter : EcsComponentConverter
    {
        [InlineProperty] [SerializeReference]
        public List<ModificationHandler> modifications = new List<ModificationHandler>();

        public override void Apply(ProtoWorld world, ProtoEntity entity)
        {
            ref var modificationsComponent = ref world.GetOrAddComponent<ModificationEffectComponent>(entity);
            modificationsComponent.ModificationHandlers.AddRange(modifications);
        }

    }
}
