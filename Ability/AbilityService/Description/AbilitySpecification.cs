namespace Game.Code.Configuration.Runtime.Ability.Description
{
    using System;
    using GameLayers.Category;
    using GameLayers.Relationship;
    using UniGame.Ecs.Proto.Cooldown;
    using UnityEngine;
    using UnityEngine.Serialization;

    [Serializable]
    public sealed class AbilitySpecification
    {
        [SerializeField]
        public float cooldown;
        
        [SerializeField]
        public CooldownType cooldownType = CooldownType.Cooldown;

        [SerializeField]
        public float radius;

        [SerializeField]
        [RelationshipIdMask]
        public RelationshipId relationshipId = (RelationshipId)~0;

        [SerializeField]
        [CategoryIdMask]
        public CategoryId categoryId = (CategoryId)~0;
        
        public float Cooldown
        {
            get
            {
                if (cooldownType != CooldownType.Speed) return cooldown;
                if (Mathf.Approximately(cooldown, 0f)) return 0;
                return 1.0f / cooldown;
            }
        }

        public float Radius => radius;

        public RelationshipId RelationshipId => relationshipId;

        public CategoryId CategoryId => categoryId;
    }
}