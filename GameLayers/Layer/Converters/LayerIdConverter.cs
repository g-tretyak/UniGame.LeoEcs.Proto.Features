namespace unigame.ecs.proto.GameLayers.Layer.Converters
{
    using System;
    using Components;
    using Game.Code.GameLayers.Layer;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class LayerIdConverter : GameObjectConverter
    {
        [SerializeField]
        public LayerId layer;

        protected sealed override void OnApply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var layerIdComponent = ref world.AddComponent<LayerIdComponent>(entity);
            layerIdComponent.Value = layer;
        }
    }
}
