namespace Game.Code.Configuration.Runtime.Effects.Abstract
{
    using Leopotam.EcsProto;


    public interface IEffectConfiguration
    {
        TargetType TargetType { get; }

        void ComposeEntity(ProtoWorld world, ProtoEntity effectEntity);
    }
}