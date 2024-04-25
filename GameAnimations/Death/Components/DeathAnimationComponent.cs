namespace unigame.ecs.proto.Core.Death.Components
{
     
    using UnityEngine.Playables;

    public struct DeathAnimationComponent : IProtoAutoReset<DeathAnimationComponent>
    {
        public PlayableAsset Animation;

        public void AutoReset(ref DeathAnimationComponent c)
        {
            c.Animation = null;
        }
    }
}