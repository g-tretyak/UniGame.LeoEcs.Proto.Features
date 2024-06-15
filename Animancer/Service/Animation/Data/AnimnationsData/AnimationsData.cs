using System;
using System.Collections.Generic;
using Game.Code.Services.Animation.Data.AnimacerActorList;
using Game.Code.Services.Animation.Data.AnimationList;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

namespace Game.Code.Services.Animation.Data.AnimnationsData
{
    [Serializable]
    public class AnimationsData
    {
        [InlineProperty, HideLabel] [Searchable]
        public List<AnimationEntry> Animations = new List<AnimationEntry>();

        public AnimationEntry GetAnimationEntry(AnimancerActorTypeId testActorType, AnimationTypeId testAnimationToPlay)
        {
            return Animations.Find(x => x.ActorType == testActorType && x.AnimationType == testAnimationToPlay);
        }
    }
}