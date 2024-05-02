namespace UniGame.Ecs.Proto.Presets.Abstract
{
    public interface IPresetAction
    {
        void Bake();
        void ApplyToTarget();
    }
}