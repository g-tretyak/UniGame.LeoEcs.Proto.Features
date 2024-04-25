namespace unigame.ecs.proto.GameAi.MoveToTarget.Data
{
    using System.Collections.Generic;
    using Code.Configuration.Runtime.Effects.Abstract;
     
    using UniGame.LeoEcs.Shared.Abstract;
    using UnityEngine;

    public struct MoveToGoalData : IApplyableComponent<MoveToGoalData>
    {
        private static readonly List<IEffectConfiguration> EmptyEffects = new List<IEffectConfiguration>();
        
        public ProtoPackedEntity Target;
        public bool Complete;
        public Vector3 Position;
        public float Priority;
        public List<IEffectConfiguration> Effects;

        public void Apply(ref MoveToGoalData component)
        {
            EmptyEffects.Clear();
            
            component.Effects = EmptyEffects;
            component.Complete = Complete;
            component.Target = Target;
            component.Position = Position;
            component.Priority = Priority;
        }
    }
}