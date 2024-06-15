using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UniModules.Editor;
#endif

using UnityEngine;

namespace Game.Code.Services.Animation.Data.AnimationList
{
    [Serializable]
    [ValueDropdown("@Game.Code.Services.Animation.Data.AnimationList.AnimationTypeId.GetAnimationTypes()", IsUniqueList = true, DropdownTitle = "AnimationType")]
    public partial struct AnimationTypeId
    {
        [SerializeField]
        public int value;

        #region static editor data

        private static AnimationTypeDataAsset _dataAsset;

        public static IEnumerable<ValueDropdownItem<AnimationTypeId>> GetAnimationTypes()
        {
#if UNITY_EDITOR
            _dataAsset ??= AssetEditorTools.GetAsset<AnimationTypeDataAsset>();
            var types = _dataAsset;
            if (types == null)
            {
                yield return new ValueDropdownItem<AnimationTypeId>()
                {
                    Text = "EMPTY",
                    Value = (AnimationTypeId)0,
                };
                yield break;
            }

            foreach (var type in types.Types)
            {
                yield return new ValueDropdownItem<AnimationTypeId>()
                {
                    Text = type.Name,
                    Value = (AnimationTypeId)type.Id,
                };
            }
#endif
            yield break;
        }

        public static string GetAnimationTypeName(AnimationTypeId slotId)
        {
#if UNITY_EDITOR
            var types = GetAnimationTypes();
            var filteredTypes = types
                .FirstOrDefault(x => x.Value == slotId);
            var slotName = filteredTypes.Text;
            return string.IsNullOrEmpty(slotName) ? string.Empty : slotName;
#endif
            return string.Empty;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Reset()
        {
            _dataAsset = null;
        }

        #endregion

        public static implicit operator int(AnimationTypeId v)
        {
            return v.value;
        }

        public static explicit operator AnimationTypeId(int v)
        {
            return new AnimationTypeId { value = v };
        }

        public override string ToString() => value.ToString();

        public override int GetHashCode() => value;

        public AnimationTypeId FromInt(int data)
        {
            value = data;

            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj is AnimationTypeId mask)
                return mask.value == value;

            return false;
        }
    }
}