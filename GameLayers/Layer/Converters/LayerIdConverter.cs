namespace unigame.ecs.proto.GameLayers.Layer.Converters
{
    using System;
    using Components;
    using Game.Code.GameLayers.Layer;
    using UnityEngine;

    [Serializable]
    public sealed class LayerIdConverter : GameObjectConverter
    {
        [SerializeField]
        public LayerId layer;

        protected sealed override void OnApply(GameObject target, ProtoWorld world, int entity)
        {
            ref var layerIdComponent = ref world.AddComponent<LayerIdComponent>(entity);
            layerIdComponent.Value = layer;
        }
    }
}
