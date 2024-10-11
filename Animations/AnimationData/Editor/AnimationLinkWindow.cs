namespace Game.Code.Configuration.Editor.Animation
{
    using Animations;
    using JetBrains.Annotations;
    //using Sirenix.OdinInspector;
    //using Sirenix.OdinInspector.Editor;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Playables;
    using Alchemy.Inspector;
    using TriInspector;
    using ButtonAttribute = Alchemy.Inspector.ButtonAttribute;
    using EnableIfAttribute = Alchemy.Inspector.EnableIfAttribute;
    using InlineEditorAttribute = Alchemy.Inspector.InlineEditorAttribute;

    [UsedImplicitly]
    public sealed class AnimationLinkWindow : EditorWindow
    {
        [InlineEditor]
        public AnimationLink animationLink;
        
        [PropertySpace(8)]
        public PlayableDirector playableDirector;

        #region static data

        [InitializeOnLoadMethod]
        public static void OnLoadInitialization()
        {
            AnimationEditorData.OnEditorOpen -= ShowWindow;
            AnimationEditorData.OnEditorOpen += ShowWindow;
        }
        
        [MenuItem("Tools/Animation/Animation Link Tool")]
        public static void ShowWindow()
        {
            var window = GetWindow<AnimationLinkWindow>();
            window.titleContent = new GUIContent("Animation Link Tool");
            window.Show();
        }
        
        public static void ShowWindow(AnimationLink link)
        {
            var window = GetWindow<AnimationLinkWindow>();
            window.titleContent = new GUIContent("Animation Link Tool");
            window.animationLink = link;
            window.Show();
        }
    
        #endregion
        
        public bool DataExists => playableDirector != null && animationLink != null;

        [Button]
        [EnableIf(nameof(DataExists))]
        public void Bake()
        {
            if (playableDirector == null) return;
            AnimationTool.BakeAnimationLink(playableDirector, animationLink);
        }
        
        [Button]
        [EnableIf(nameof(DataExists))]
        public void ApplyToDirector()
        {
            if (playableDirector == null) return;
            AnimationTool.ApplyBindings(playableDirector, animationLink);
        }

        //protected override void OnImGUI()
        //{
        //    base.OnImGUI();
            
        //    if (playableDirector == null && Selection.activeGameObject != null)
        //    {
        //        var target = Selection.activeGameObject;
        //        var director = target.GetComponent<PlayableDirector>();
        //        playableDirector = director;
        //    }
        //}
        
    }
}