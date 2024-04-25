namespace unigame.ecs.proto.Ability.Common.Components
{
    using System;
    using Game.Code.Animations.EffectMilestones;
    using Leopotam.EcsProto;


    public struct AbilityEffectMilestonesComponent : IProtoAutoReset<AbilityEffectMilestonesComponent>
    {
        public EffectMilestone[] Milestones;
        
        public void AutoReset(ref AbilityEffectMilestonesComponent c)
        {
            c.Milestones = Array.Empty<EffectMilestone>();
        }
    }
}