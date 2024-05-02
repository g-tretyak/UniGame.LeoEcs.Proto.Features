namespace UniGame.Ecs.Proto.Ability.Common.Components
{
    using UnityEngine.Serialization;

    /// <summary>
    /// Запрос применить умение в конкретной ячейке умений.
    /// </summary>
    public struct ApplyAbilityBySlotSelfRequest
    {
        [FormerlySerializedAs("AbilityCellId")] public int AbilitySlot;
    }
}