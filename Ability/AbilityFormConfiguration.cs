namespace Game.Code.Configuration.Runtime.Ability
{
    using Leopotam.EcsProto;
    using UnityEngine;

    public abstract class AbilityFormConfiguration : ScriptableObject
    {
        public abstract void Run(IProtoSystems systems);
    }
}