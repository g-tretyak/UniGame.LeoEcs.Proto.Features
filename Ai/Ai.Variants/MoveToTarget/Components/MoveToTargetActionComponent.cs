namespace unigame.ecs.proto.GameAi.MoveToTarget.Components
{
    using System;
    using System.Collections.Generic;
    using Game.Code.Configuration.Runtime.Effects.Abstract;
    using Unity.Mathematics;

    [Serializable]
    public struct MoveToTargetActionComponent
    {
        public float3 Position;
        public List<IEffectConfiguration> Effects;
    }
}
