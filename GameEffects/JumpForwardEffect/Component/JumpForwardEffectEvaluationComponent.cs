namespace UniGame.Ecs.Proto.GameEffects.JumpForwardEffect.Component
{
     
    using UnityEngine;

    /// <summary>
    /// Evaluation data for jump forward effect
    /// </summary>
    public struct JumpForwardEffectEvaluationComponent
    {
        public Transform SourceTransform;
        public Vector3 EndPosition;
        public float Duration;
    }
}