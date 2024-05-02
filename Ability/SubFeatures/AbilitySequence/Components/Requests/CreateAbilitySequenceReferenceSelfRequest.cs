namespace UniGame.Ecs.Proto.Ability.SubFeatures.AbilitySequence
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// create new ability sequence
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct CreateAbilitySequenceReferenceSelfRequest : IProtoAutoReset<CreateAbilitySequenceReferenceSelfRequest>
    {
        public ProtoPackedEntity Owner;
        public AbilitySequenceReference Reference;
        
        public void AutoReset(ref CreateAbilitySequenceReferenceSelfRequest c)
        {
            c.Owner = default;
            c.Reference = null;
        }
    }
    
    /// <summary>
    /// create new ability sequence
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct CreateAbilitySequenceSelfRequest : IProtoAutoReset<CreateAbilitySequenceSelfRequest>
    {
        public string Name;
        public ProtoPackedEntity Owner;
        public List<ProtoEntity> Abilities;
        
        public void AutoReset(ref CreateAbilitySequenceSelfRequest c)
        {
            c.Abilities ??= new List<ProtoEntity>();
            c.Abilities.Clear();
            c.Name = string.Empty;
        }
    }
}