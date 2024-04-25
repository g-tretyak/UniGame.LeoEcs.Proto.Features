namespace unigame.ecs.proto.TargetSelection.Components
{
    using System;
    using Game.Code.GameLayers.Category;
    using Game.Code.GameLayers.Layer;
    using Game.Code.GameLayers.Relationship;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// mark entity as target for range selection
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct SqrRangeTargetSelectionComponent
    {
        public float Radius;
        public CategoryId Category;
        public RelationshipId Relationship;
        public LayerId Layer;
        public ProtoPackedEntity Target;
    }
    
}