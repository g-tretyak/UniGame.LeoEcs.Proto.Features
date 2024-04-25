namespace unigame.ecs.proto.Presets.SpotLightSettings.Converters
{
     
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UnityEngine;
    
    public sealed class MonoSpotLightSettingsPresetSourceConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        [InlineProperty]
        [HideLabel]
        public SpotLightSettingsSourceConverter spotLightConverter = new SpotLightSettingsSourceConverter();

        public sealed override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            spotLightConverter.Apply(world, entity);
        }
    }
}