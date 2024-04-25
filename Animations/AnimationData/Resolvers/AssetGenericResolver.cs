namespace Game.Code.Animations
{
    using System;
    using Resolvers;
    using UnityEngine.Playables;

    [Serializable]
    public class AssetGenericResolver : IPlayableReferenceResolver
    {
        public void Resolve(IPlayableReference reference, PlayableDirector director)
        {
            if (reference is not AssetObjectReference objectReference)
                return;
        }
    }
}