namespace UniGame.Ecs.Proto.Tools.Converters
{
    using Game.Code.Animations;
    //using Sirenix.OdinInspector;
    using Alchemy.Inspector;
    using TriInspector;
    using UnityEngine;
    using UnityEngine.Playables;
    using InlineEditorAttribute = Alchemy.Inspector.InlineEditorAttribute;
    using ButtonAttribute = Alchemy.Inspector.ButtonAttribute;
    using EnableIfAttribute = Alchemy.Inspector.EnableIfAttribute;

#if UNITY_EDITOR
#endif

    public class TimeLineAnimationBaker : MonoBehaviour
    {
        [PropertySpace(8)]
        [InlineEditor]
        public AnimationLink animationLink;

        [PropertySpace(8)]
        public PlayableDirector director;

        public bool IsDataAvailable => director !=null && animationLink != null && animationLink.animation != null;
        
        [Button]
        [EnableIf(nameof(IsDataAvailable))]
        public void Bake()
        {
            AnimationTool.BakeAnimationLink(director, animationLink);
        }

        [Button]
        [EnableIf(nameof(IsDataAvailable))]
        public void Apply()
        {
            AnimationTool.ApplyBindings(director, animationLink);
        }

        [Button]
        [EnableIf(nameof(IsDataAvailable))]
        public void ClearTimeline()
        {
            AnimationTool.ClearReferences(director, animationLink.animation);
        }
        
        [Button]
        public void ClearBacking()
        {
            animationLink?.Clear();
        }
        
        
    }
}