using Game.Code.Services.Animation.Data.AnimacerActorList;
using Game.Code.Services.Animation.Data.AnimationList;
using Game.Code.Services.Animation.Data.AnimnationsData;
using UniGame.GameFlow.Runtime.Interfaces;

namespace Game.Code.Services.Animation
{
    public interface IAnimationService : IGameService
    {
        AnimationEntry GetAnimationEntry(AnimancerActorTypeId actorType, AnimationTypeId animationToPlay);
    }
}