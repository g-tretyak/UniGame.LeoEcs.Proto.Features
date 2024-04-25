namespace unigame.ecs.proto.Gameplay.Death.Aspects
{
    using System;
    using Characteristics.Health.Components;
    using Core.Components;
    using Core.Death.Components;
     
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class DeathAspect : EcsAspect
    {
        public ProtoPool<PrepareToDeathComponent> PrepareToDeath;
        public ProtoPool<PlayableDirectorComponent> Director;
        public ProtoPool<DeadAnimationEvaluateComponent> Evaluate;
        public ProtoPool<DeathAnimationComponent> Animation;
        public ProtoPool<AwaitDeathCompleteComponent> AwaitDeath;
        public ProtoPool<DisabledComponent> Disabled;
        public ProtoPool<DeathCompletedComponent> Completed;
        public ProtoPool<ChampionComponent> Champion;
    }
}