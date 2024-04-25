namespace unigame.ecs.proto.Presets.Directional_Light.Converters
{
     
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UnityEngine;
    public class MonoDirectionalLightSettingsPresetSourceConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        [InlineProperty]
        [HideLabel]
        public DirectionalLightSettingsSourceConverter directionalLightConverter = new();

        public sealed override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            directionalLightConverter.Apply(world, entity);
        }
    }
}