namespace Game.Code.Animations.EffectMilestones
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class EffectMilestonesData
    {
        [SerializeField]
        public List<EffectMilestone> effectMilestones = new List<EffectMilestone>();

        public void AddMilestone(float time)
        {
            effectMilestones.Add(new EffectMilestone
            {
                Time = time
            });
        }
        
        public void Clear()
        {
            effectMilestones.Clear();
        }
        
    }
}