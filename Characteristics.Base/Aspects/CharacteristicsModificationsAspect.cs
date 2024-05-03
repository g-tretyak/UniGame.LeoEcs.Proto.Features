namespace UniGame.Ecs.Proto.Characteristics.Base.Aspects
{
    using System;
    using Components;
    using Components.Requests;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// modifications of characteristics values
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class CharacteristicsModificationsAspect : EcsAspect
    {
        public ProtoPool<BaseModificationsValueComponent> BaseModificationValue;
        public ProtoPool<PercentModificationsValueComponent> PercentModificationValue;
        public ProtoPool<MaxLimitModificationsValueComponent> MaxLimitModificationValue;
        
        public ProtoPool<ModificationSourceTrackComponent> ModificationSourceTrack;
        public ProtoPool<ModificationSourceLinkComponent> ModificationSourceLink;
        public ProtoPool<ModificationSourceComponent> ModificationSource;
        public ProtoPool<ModificationPercentComponent> ModificationPercent;
        public ProtoPool<ModificationMaxLimitComponent> ModificationMaxLimit;
        public ProtoPool<ModificationComponent> Modification;
        
        //requests
        public ProtoPool<AddModificationRequest> AddModification;
        public ProtoPool<CreateModificationRequest> CreateModification;
    }
}