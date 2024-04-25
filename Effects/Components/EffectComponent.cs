namespace unigame.ecs.proto.Effects.Components
{
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// Компонент эффекта на цели.
    /// </summary>
    public struct EffectComponent
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;
    }
}