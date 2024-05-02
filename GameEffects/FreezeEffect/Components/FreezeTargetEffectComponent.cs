namespace UniGame.Ecs.Proto.GameEffects.FreezeEffect.Components
{
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// Says that the freezing effect is used on the target
    /// </summary>
    public struct FreezeTargetEffectComponent
    {
        public ProtoPackedEntity Source;
        // Creating time ability + Duration
        public float DumpTime;
    }
}