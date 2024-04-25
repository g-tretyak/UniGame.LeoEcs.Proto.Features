namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySequence
{
    using System;
    using System.Collections.Generic;
    using Game.Code.Configuration.Runtime.Ability.Description;
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
    public struct CreateAbilitySequenceByIdSelfRequest : IProtoAutoReset<CreateAbilitySequenceByIdSelfRequest>
    {
        public string Name;
        public ProtoPackedEntity Owner;
        public List<AbilityId> Abilities;
        
        public void AutoReset(ref CreateAbilitySequenceByIdSelfRequest c)
        {
            c.Abilities ??= new List<AbilityId>();
            c.Abilities.Clear();
            c.Name = string.Empty;
        }
    }
}