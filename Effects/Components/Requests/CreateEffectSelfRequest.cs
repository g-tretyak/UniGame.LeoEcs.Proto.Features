namespace UniGame.Ecs.Proto.Effects.Components
{
    using Game.Code.Configuration.Runtime.Effects.Abstract;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// Запрос создания эффекта на цель.
    /// </summary>
    public struct CreateEffectSelfRequest
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;

        public IEffectConfiguration Effect;
    }
}