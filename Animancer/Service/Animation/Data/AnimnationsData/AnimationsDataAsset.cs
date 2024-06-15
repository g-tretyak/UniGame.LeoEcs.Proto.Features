using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Code.Services.Animation.Data.AnimnationsData
{
    [CreateAssetMenu(menuName = "Gameplay/Data/Animation/AnimationsData Asset", fileName = "AnimationsData Asset")]
    public class AnimationsDataAsset : ScriptableObject
    {
        [InlineProperty, HideLabel]
        public AnimationsData Data;
    }
}