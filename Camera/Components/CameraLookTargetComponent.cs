namespace UniGame.Ecs.Proto.Camera.Components
{
    using System;
    using Unity.Mathematics;
    using UnityEngine;

    /// <summary>
    /// Компонент цели следования камеры.
    /// </summary>
    [Serializable]
    public struct CameraLookTargetComponent
    {
        public float Speed;
        public float3 Offset;
    }
}