namespace Game.Ecs.Input.Data.ActionMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    //using Sirenix.OdinInspector;
    using Alchemy.Inspector;
    using TriInspector;
    using UnityEngine;

#if UNITY_EDITOR
    using UniModules.Editor;
#endif

    [Serializable]
    [ValueDropdown("@Game.Ecs.Input.Data.InputActionsMapId.GetIds()")]
    public struct InputActionsMapId
    {
        [SerializeField]
        private int _value;

        #region statis editor data

        private static InputActionsMapData _inputActionsData;

        public static IEnumerable<ValueDropdownItem<InputActionsMapId>> GetIds()
        {
#if UNITY_EDITOR
            _inputActionsData ??= AssetEditorTools.GetAsset<InputActionsMapData>();
            var inputActionData = _inputActionsData;
            if (inputActionData == null)
            {
                yield return new ValueDropdownItem<InputActionsMapId>()
                {
                    Text = "EMPTY",
                    Value = (InputActionsMapId)0,
                };
                yield break;
            }

            foreach (var inputActionMap in inputActionData.inputActionsMaps)
            {
                yield return new ValueDropdownItem<InputActionsMapId>()
                {
                    Text = inputActionMap.name,
                    Value = (InputActionsMapId)inputActionMap.id,
                };
            }
#endif
            yield break;
        }

        public static string GetName(InputActionsMapId inputActionsMapId)
        {
#if UNITY_EDITOR
            var ids = GetIds();
            var item = ids.FirstOrDefault(x => x.Value == inputActionsMapId);
            var itemText = item.Text;
            return string.IsNullOrEmpty(itemText) ? string.Empty : itemText;
#endif
            return string.Empty;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Reset()
        {
            _inputActionsData = null;
        }

        #endregion

        public static implicit operator int(InputActionsMapId v)
        {
            return v._value;
        }

        public static explicit operator InputActionsMapId(int v)
        {
            return new InputActionsMapId { _value = v };
        }

        public override string ToString() => _value.ToString();

        public override int GetHashCode() => _value;

        public InputActionsMapId FromInt(int data)
        {
            _value = data;

            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj is InputActionsMapId mask)
                return mask._value == _value;

            return false;
        }
    }
}