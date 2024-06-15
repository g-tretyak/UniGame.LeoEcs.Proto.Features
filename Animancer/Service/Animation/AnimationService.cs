using Cysharp.Threading.Tasks;
using Game.Code.Services.Animation.Data.AnimacerActorList;
using Game.Code.Services.Animation.Data.AnimationList;
using Game.Code.Services.Animation.Data.AnimnationsData;

namespace Game.Code.Services.Animation
{
    using System;
    using UniGame.UniNodes.GameFlow.Runtime;

    [Serializable]
    public class AnimationService : GameService, IAnimationService
    {
        private readonly AnimationsData _animationsData;

        public AnimationService(AnimationsData animationsData)
        {
           _animationsData = animationsData;
        }

        public AnimationEntry GetAnimationEntry(AnimancerActorTypeId actorType, AnimationTypeId animationToPlay)
        {
            return _animationsData.GetAnimationEntry(actorType, animationToPlay);
        }
    }
}