namespace UniGame.Ecs.Proto.Movement.Components
{
    using UnityEngine;

    /// <summary>
    /// Целевая позиция для перемещения.
    /// Компонент является событием и удаляется в конце цикла.
    /// </summary>
    public struct MovementPointSelfRequest
    {
        public Vector3 DestinationPosition;
    }
}