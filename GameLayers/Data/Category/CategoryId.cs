namespace Game.Code.GameLayers.Category
{
    using System;
    using UnityEngine;
    using UnityEngine.Serialization;

    [Serializable]
    public struct CategoryId
    {
        [SerializeField]
        public int value;

        public static implicit operator int(CategoryId v)
        {
            return v.value;
        }

        public static explicit operator CategoryId(int v)
        {
            return new CategoryId { value = v };
        }

        public override string ToString() => value.ToString();

        public override int GetHashCode() => value;

        public CategoryId FromInt(int data)
        {
            value = data;
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj is CategoryId mask)
                return mask.value == value;
            
            return false;
        }
    }
}
