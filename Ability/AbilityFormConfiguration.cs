namespace Game.Code.Configuration.Runtime.Ability
{
     
    using UnityEngine;

    public abstract class AbilityFormConfiguration : ScriptableObject
    {
        public abstract void Run(EcsSystems systems);
    }
}