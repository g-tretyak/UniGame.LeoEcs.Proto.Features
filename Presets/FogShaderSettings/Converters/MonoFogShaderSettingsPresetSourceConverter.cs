namespace UniGame.Ecs.Proto.Presets.FogShaderSettings.Converters
{
    using Leopotam.EcsProto;
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UnityEngine;
    public sealed class MonoFogShaderSettingsPresetSourceConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        [InlineProperty]
        [HideLabel]
        public FogShaderSettingsSourceConverter fogShaderConverter = new FogShaderSettingsSourceConverter();

        public sealed override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            fogShaderConverter.Apply(world, entity);
        }
    }
}