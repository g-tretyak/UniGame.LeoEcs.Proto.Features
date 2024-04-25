namespace unigame.ecs.proto.GameLayers.Relationship.Converters
{
    using System;
    using Components;
    using Game.Code.GameLayers.Relationship;
    using UnityEngine;

    [Serializable]
    public sealed class RelationshipIdConverter : GameObjectConverter
    {
        [SerializeField] 
        public RelationshipId relationship;

        protected override void OnApply(GameObject target, ProtoWorld world, int entity)
        {
            ref var relationshipComponent = ref world.AddComponent<RelationshipIdComponent>(entity);
            relationshipComponent.Value = relationship;
        }
    }
}