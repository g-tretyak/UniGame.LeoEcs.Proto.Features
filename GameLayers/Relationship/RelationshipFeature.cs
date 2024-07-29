namespace UniGame.Ecs.Proto.GameLayers.Relationship
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
    using Object = UnityEngine.Object;

    [Serializable]
    public sealed class RelationshipFeature : LeoEcsSystemAsyncFeature
    {
        [SerializeField]
        private LayerIdConfiguration _layerIdConfiguration;
        [SerializeField]
        private RelationshipIdMap _relationshipIdMap;
        [SerializeField]
        private RelationshipId _selfRelationship;
    
        public override UniTask InitializeAsync(IProtoSystems ecsSystems)
        {
            var protoWorld = ecsSystems.GetWorld();
            var layerIdConfiguration = Object.Instantiate(_layerIdConfiguration);
            var relationshipIdMap = Object.Instantiate(_relationshipIdMap);

            protoWorld.SetGlobal(layerIdConfiguration);
            protoWorld.SetGlobal(relationshipIdMap);


            ecsSystems.Add(new RelationshipToolsSystem(_layerIdConfiguration, _relationshipIdMap, _selfRelationship));
            
            return UniTask.CompletedTask;
        }
    }
}
