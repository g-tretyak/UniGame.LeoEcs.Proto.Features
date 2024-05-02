namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySequence.Assets
{
    using Data;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Ability Sequence Asset", menuName = "Proto Features/Ability/Ability Sequence Asset")]
    public class AbilitySequenceAsset : ScriptableObject
    {
        [InlineProperty] 
        [HideLabel] 
        public AbilitySequenceReference sequence = new AbilitySequenceReference();
    }
}