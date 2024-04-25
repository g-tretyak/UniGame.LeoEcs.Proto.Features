namespace unigame.ecs.proto.GameLayers.Relationship.Converters
{
    using System;
    using System.Threading;
    using Code.GameLayers.Relationship;
    using Components;
     
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Converter.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Extensions;
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