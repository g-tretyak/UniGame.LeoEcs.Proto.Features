namespace Game.Code.Configuration.Runtime.Ability
{
    using System.Collections.Generic;
    using Animations;
    using Description;
    using UniGame.AddressableTools.Runtime.AssetReferencies;
    using UnityEngine;

#if ODIN_INSPECTOR
    using Sirenix.OdinInspector;
#endif
    
#if UNITY_EDITOR
    using UniModules.Editor;
#endif

    [CreateAssetMenu(fileName = "Ability Configuration", menuName = "Game/Ability/Ability Configuration")]
    public sealed class AbilityConfiguration : ScriptableObject
    {
        [TitleGroup("Specification")]
        [InlineProperty]
        [HideLabel]
        [SerializeField]
        public AbilitySpecification specification;
        
        public bool useAnimation = true;

        [PropertySpace(8)]
        [TitleGroup("Animation")]
        [InlineProperty]
        [HideLabel]
        [ShowIf(nameof(useAnimation))]
        public AddressableValue<AnimationLink> animationLink;
        
        [TitleGroup("Animation")]
        [HideIf(nameof(useAnimation))]
        public float duration = 0.2f;
        
        [PropertySpace(8)]
        [SerializeReference]
        public List<IAbilityBehaviour> abilityBehaviours = new List<IAbilityBehaviour>();
        
        [Button]
        public void Save()
        {
#if UNITY_EDITOR
            this.SaveAsset();
#endif
        }
    }
}