namespace unigame.ecs.proto.GameLayers.Category.Converters
{
    using System;
    using Components;
    using Game.Code.GameLayers.Category;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class CategoryIdConverter : GameObjectConverter
    {
        [SerializeField]
        public CategoryId categoryId;

        protected override void OnApply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var category = ref world.AddComponent<CategoryIdComponent>(entity);
            category.Value = categoryId;
        }
    }
}
