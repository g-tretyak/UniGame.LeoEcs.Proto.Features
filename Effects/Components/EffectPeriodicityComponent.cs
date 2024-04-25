namespace unigame.ecs.proto.Effects.Components
{
    using Leopotam.EcsProto;


    /// <summary>
    /// Компонент периодичности эффекта.
    /// </summary>
    public struct EffectPeriodicityComponent : IProtoAutoReset<EffectPeriodicityComponent>
    {
        /// <summary>
        /// Периодичность эффекта.
        /// </summary>
        public float Periodicity;
        
        /// <summary>
        /// Последнее время применения эффекта. Если <see cref="LastApplyingTime"/> + <see cref="Periodicity"/> больше
        /// или равен текущему игровому времени, то эффект применится.
        /// </summary>
        public float LastApplyingTime;
        
        public void AutoReset(ref EffectPeriodicityComponent c)
        {
            c.Periodicity = 0.0f;
            c.LastApplyingTime = float.MinValue;
        }
    }
}