namespace Game.Code.Animations
{
    //using Sirenix.OdinInspector;
    using Alchemy.Inspector;
    using TriInspector;
    using UnityEngine;
    using HideLabelAttribute = Alchemy.Inspector.HideLabelAttribute;

    [CreateAssetMenu(fileName = "Animation Binding Data", menuName = "Game/Animation/Animation Binding Data")]
    public sealed class AnimationBindingData : ScriptableObject
    {
        [SerializeField]
        [InlineProperty]
        [HideLabel]
        public PlayableBindingData data = new PlayableBindingData();
    }
    
}