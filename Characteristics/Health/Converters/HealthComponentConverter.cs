namespace UniGame.Ecs.Proto.Characteristics.Health.Converters
{
    using System;
    using Components;
    
    /// <summary>
    /// Converts health data and applies it to the target game object in the ECS world.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class HealthComponentConverter : GameCharacteristicConverter<HealthComponent>
    {

    }
}