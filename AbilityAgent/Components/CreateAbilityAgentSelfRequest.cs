namespace unigame.ecs.proto.AbilityAgent.Components
{
    using System;
    using Game.Code.Configuration.Runtime.Ability;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// Self request to create ability agent.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct CreateAbilityAgentSelfRequest
    {
        public ProtoPackedEntity Owner;
        public AbilityCell AbilityCell;
    }
}