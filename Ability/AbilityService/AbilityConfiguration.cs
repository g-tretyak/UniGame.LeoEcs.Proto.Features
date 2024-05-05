namespace Game.Code.Configuration.Runtime.Ability
{
    using System.Collections.Generic;
    using Animations;
    using Description;
    using Sirenix.OdinInspector;
    using UniGame.AddressableTools.Runtime.AssetReferencies;
    using UnityEngine;

#if UNITY_EDITOR
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
        
        [SerializeField]
        public bool isBlocked;
        
    }
}