namespace unigame.ecs.proto.Presets.Components
{
    using System;
    using UnityEngine;

    [Serializable]
    public struct LightPreset
    {
        public Color Color;
        public float Intencivity;
        public float ShadowStrength;
        public float Range;
        public float SpotAngle;
        public LightType Type;
    }
}