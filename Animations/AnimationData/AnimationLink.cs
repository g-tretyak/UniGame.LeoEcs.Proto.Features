﻿namespace Game.Code.Animations
{
    using EffectMilestones;
    //using Sirenix.OdinInspector;
    using Alchemy.Inspector;
    using TriInspector;
    using UnityEngine;
    using UnityEngine.Playables;
    using UnityEngine.Serialization;
    using OnValueChangedAttribute = Alchemy.Inspector.OnValueChangedAttribute;
    using HideLabelAttribute = Alchemy.Inspector.HideLabelAttribute;
    using ShowIfAttribute = Alchemy.Inspector.ShowIfAttribute;
    using ButtonAttribute = TriInspector.ButtonAttribute;

#if UNITY_EDITOR
    using UniModules.Editor;
#endif

    [CreateAssetMenu(fileName = "Animation Link", menuName = "Game/Animation/Animation Link")]
    public sealed class AnimationLink : ScriptableObject
    {
        [FormerlySerializedAs("_animation")] 
        [OnValueChanged(nameof(BakeMilestones))]
        [SerializeField]
        public PlayableAsset animation;

        public DirectorWrapMode wrapMode = DirectorWrapMode.Hold;
        
        [Tooltip("If animationSpeed is 0, animation will be played with default calculated speed")]
        public float animationSpeed = 0f;
        
        [Tooltip("If duration is 0, animation will be played with default playable asset duration")]
        public float duration = 0;
        
        [SerializeField]
        [InlineProperty]
        [HideLabel]
        public PlayableBindingData bindingData = new PlayableBindingData();

        [PropertySpace(8)]
        [Space]
        [SerializeField]
        [InlineProperty]
        [HideLabel]
        public EffectMilestonesData milestones;

        public bool showCommands = true;
        
        public float Duration => duration <= 0 && animation!=null ? (float)animation.duration : duration ;

        [Button(nameof(BakeMilestones))]
        [ShowIf(nameof(showCommands))]
        public void BakeMilestones()
        {
            AnimationTool.BakeMilestones(milestones,animation);
#if UNITY_EDITOR
            this.MarkDirty();
#endif
        }

        [Button(nameof(Clear))]
        [ShowIf(nameof(showCommands))]
        public void Clear()
        {
            bindingData.Clear();
            milestones.Clear();
#if UNITY_EDITOR
            this.MarkDirty();
#endif
        }


        [Button(nameof(OpenEditor))]
        [ShowIf(nameof(showCommands))]
        public void OpenEditor()
        {
            AnimationEditorData.OpenEditor(this);
        }

    }
}