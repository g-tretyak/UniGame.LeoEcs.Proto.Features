namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Behaviours
{
    using System;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using Tools;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// create animations options for critical strike
    /// </summary>
    [Serializable]
    public class CriticalAnimationsBehaviour : IAbilityBehaviour
    {
        
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity)
        {
            var tools = world.GetGlobal<AbilityTools>();
        }
    }

    [Serializable]
    public class AbilityOptionData
    {
        public AbilityOrderOptions order = AbilityOrderOptions.Replace;
        public AbilityId abilityId;
    }

    [Serializable]
    public enum AbilityOrderOptions : byte
    {
        Replace,
        After,
    }
}