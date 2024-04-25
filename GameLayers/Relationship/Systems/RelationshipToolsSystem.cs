namespace unigame.ecs.proto.GameLayers.Relationship.Systems
{
    using System;
    using Game.Code.GameLayers.Layer;
    using Game.Code.GameLayers.Relationship;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
    
    /// <summary>
    /// destroy releationship tools on ecs destroy
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class RelationshipToolsSystem : IEcsDestroySystem,IProtoInitSystem
    {
        private ProtoWorld _world;
        
        private LayerIdConfiguration _layerIdConfiguration;
        private RelationshipIdMap _relationshipIdMap;
        private RelationshipId _selfRelationship;
        
        public RelationshipToolsSystem(LayerIdConfiguration layerIdConfiguration,
            RelationshipIdMap relationshipIdMap, 
            RelationshipId selfRelationship)
        {
            _layerIdConfiguration = layerIdConfiguration;
            _relationshipIdMap = relationshipIdMap;
            _selfRelationship = selfRelationship;
            
            RelationshipTool.Initialize(_layerIdConfiguration.LayersIds, 
                _relationshipIdMap.RelationshipMatrix, 
                _selfRelationship);
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
        }


        public void Destroy(IProtoSystems systems)
        {
            RelationshipTool.Destroy();
        }
    }
}