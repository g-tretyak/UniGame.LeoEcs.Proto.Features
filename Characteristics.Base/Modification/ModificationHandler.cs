namespace unigame.ecs.proto.Characteristics.Base.Modification
{
    using System;
    using Leopotam.EcsProto;
    using UnityEngine;
    using UnityEngine.Serialization;

    [Serializable]
    public abstract class ModificationHandler
    {
        [SerializeField]
        public float value;
     
        [SerializeField]
        public bool isPercent;
        
        [SerializeField]
        public bool allowedSummation = true;

        [SerializeField]
        public bool isMaxLimitModification;

        protected virtual Modification Modification => Create();

        public abstract void AddModification(ProtoWorld world,ProtoEntity sourceEntity, ProtoEntity destinationEntity);
        
        public abstract void RemoveModification(ProtoWorld world,ProtoEntity sourceEntity, ProtoEntity destinationEntity);

        public virtual Modification Create()
        {
            return new Modification(value, isPercent,allowedSummation,isMaxLimitModification);
        }
    }
}