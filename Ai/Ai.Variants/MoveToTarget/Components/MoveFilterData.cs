namespace unigame.ecs.proto.GameAi.MoveToTarget.Components
{
    using System;
    using Game.Code.GameLayers.Category;
    using Game.Code.GameLayers.Relationship;

    [Serializable]
    public struct MoveFilterData
    {
        /// <summary>
        /// Маска для фильтр отношения при поиске целей
        /// </summary>
        [RelationshipIdMask]
        public RelationshipId Relationship;
        
        [CategoryIdMask]
        public CategoryId CategoryId;
        
        public float SensorDistance;
    }
}