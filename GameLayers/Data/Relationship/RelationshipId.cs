namespace Game.Code.GameLayers.Relationship
{
    using System;
    using UnityEngine;
    using UnityEngine.Serialization;

    [Serializable]
    public struct RelationshipId
    {
        [SerializeField]
        public int value;

        public static implicit operator int(RelationshipId v)
        {
            return v.value;
        }

        public static explicit operator RelationshipId(int v)
        {
            return new RelationshipId { value = v };
        }

        public override string ToString() => value.ToString();

        public override int GetHashCode() => value;

        public RelationshipId FromInt(int data)
        {
            value = data;
            
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj is RelationshipId mask)
                return mask.value == value;
            
            return false;
        }
    }
}