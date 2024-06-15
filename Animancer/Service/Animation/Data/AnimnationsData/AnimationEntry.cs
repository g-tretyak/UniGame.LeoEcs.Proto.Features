using System;
using Animancer;
using Game.Code.Services.Animation.Data.AnimacerActorList;
using Game.Code.Services.Animation.Data.AnimationList;
using Sirenix.OdinInspector;

namespace Game.Code.Services.Animation.Data.AnimnationsData
{
    [Serializable]
    public class AnimationEntry
    {
        public string Name;
        public AnimancerActorTypeId ActorType;
        public AnimationTypeId AnimationType;
        public ClipTransitionAsset Animation;
    }
}