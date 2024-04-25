namespace unigame.ecs.proto.GameLayers.Relationship
{
    using System;
    using Cysharp.Threading.Tasks;
    using Game.Code.GameLayers.Layer;
    using Game.Code.GameLayers.Relationship;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class RelationshipFeature : LeoEcsSystemAsyncFeature
    {
        [SerializeField]
        private LayerIdConfiguration _layerIdConfiguration;
        [SerializeField]
        private RelationshipIdMap _relationshipIdMap;
        [SerializeField]
        private RelationshipId _selfRelationship;
    
        public override UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new RelationshipToolsSystem(_layerIdConfiguration, _relationshipIdMap, _selfRelationship));
            
            return UniTask.CompletedTask;
        }
    }
}
