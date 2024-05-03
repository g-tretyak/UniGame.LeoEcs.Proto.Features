namespace UniGame.Ecs.Proto.Characteristics
{
    using System;
    using Characteristics;
    using Cooldown;
    using Duration;
    using Health;

    [Serializable]
    public class CooldownModificationFactory : DefaultModificationFactory<CooldownModificationHandler>{}
    
    [Serializable]
    public class DurationModificationFactory : DefaultModificationFactory<DurationModificationHandler>{}
    
    [Serializable]
    public class HealthModificationFactory : DefaultModificationFactory<HealthModificationHandler>{}
}