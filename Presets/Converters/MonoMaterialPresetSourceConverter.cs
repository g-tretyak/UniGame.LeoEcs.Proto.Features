namespace unigame.ecs.proto.Presets.Converters
{
    using System.Threading;
     
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UnityEngine;

    public sealed class MonoMaterialPresetSourceConverter : MonoLeoEcsConverter
    {
        [HideLabel]
        [InlineProperty]
        public MaterialPresetSourceConverter converter = new MaterialPresetSourceConverter();
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            converter.Apply(world,entity);
        }
    }
}