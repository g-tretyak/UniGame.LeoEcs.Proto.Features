using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

#if UNITY_EDITOR
using UniModules.Editor;
#endif

namespace Game.Code.Services.Animation.Data.AnimacerActorList
{
    [Serializable]
    [ValueDropdown("@Game.Code.Services.Animation.Data.AnimacerActorList.AnimancerActorTypeId.GetAnimancerActorTypes()", IsUniqueList = true,
        DropdownTitle = "AnimancerActorType")]
    public partial struct AnimancerActorTypeId
    {
        [SerializeField]
        public int value;

        #region static editor data

        private static AnimancerActorTypeDataAsset _dataAsset;

        public static IEnumerable<ValueDropdownItem<AnimancerActorTypeId>> GetAnimancerActorTypes()
        {
#if UNITY_EDITOR
            _dataAsset ??= AssetEditorTools.GetAsset<AnimancerActorTypeDataAsset>();
            var types = _dataAsset;
            if (types == null)
            {
                yield return new ValueDropdownItem<AnimancerActorTypeId>()
                {
                    Text = "EMPTY",
                    Value = (AnimancerActorTypeId)0,
                };
                yield break;
            }

            foreach (var type in types.Types)
            {
                yield return new ValueDropdownItem<AnimancerActorTypeId>()
                {
                    Text = type.Name,
                    Value = (AnimancerActorTypeId)type.Id,
                };
            }
#endif
            yield break;
        }

        public static string GetAnimancerActorTypeName(AnimancerActorTypeId slotId)
        {
#if UNITY_EDITOR
            var types = GetAnimancerActorTypes();
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

        public static implicit operator int(AnimancerActorTypeId v)
        {
            return v.value;
        }

        public static explicit operator AnimancerActorTypeId(int v)
        {
            return new AnimancerActorTypeId { value = v };
        }

        public override string ToString() => value.ToString();

        public override int GetHashCode() => value;

        public AnimancerActorTypeId FromInt(int data)
        {
            value = data;

            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj is AnimancerActorTypeId mask)
                return mask.value == value;

            return false;
        }
    }
}