namespace unigame.ecs.proto.Ability.SubFeatures.AbilitySequence.Data
{
    using System;
    using System.Collections.Generic;
    using Game.Code.Services.Ability;

    [Serializable]
    public class AbilitySequenceReference
    {
        public string name;
        
        public List<AbilityConfigurationValue> sequence = new List<AbilityConfigurationValue>();
    }
    
}