namespace UniGame.Ecs.Proto.Movement.Components
{
    using Unity.Mathematics;

    /// <summary>
    /// Целевая позиция для перемещения.
    /// Компонент является событием и удаляется в конце цикла.
    /// </summary>
    public struct MovementPointSelfRequest
    {
        public float3 Value;
    }
}