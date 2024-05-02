namespace UniGame.Ecs.Proto.GameLayers.Relationship.Converters
{
    using System;
    using Components;
    using Game.Code.GameLayers.Relationship;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class RelationshipIdConverter : GameObjectConverter
    {
        [SerializeField] 
        public RelationshipId relationship;

        protected override void OnApply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var relationshipComponent = ref world.AddComponent<RelationshipIdComponent>(entity);
            relationshipComponent.Value = relationship;
        }
    }
}