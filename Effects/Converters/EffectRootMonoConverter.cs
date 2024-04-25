namespace unigame.ecs.proto.Effects.Converters
{
    using Sirenix.OdinInspector;

#if UNITY_EDITOR
    using UniModules.Editor;
#endif
    
    public class EffectRootMonoConverter : MonoLeoEcsConverter<EffectRootConverter>
    {
        [Button]
        public void BakeActive()
        {
#if UNITY_EDITOR
            converter ??= new EffectRootConverter();
            converter.Bake(gameObject);
            
            this.MarkDirty();
            gameObject.MarkDirty();
#endif
        }
        
    }
}