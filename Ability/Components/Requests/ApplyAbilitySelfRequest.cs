namespace UniGame.Ecs.Proto.Ability.Common.Components
{
    using System;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// Запрос применить целевое умение, умение должно принадлежать сущности.
    /// </summary>
    [Serializable]
    public struct ApplyAbilitySelfRequest
    {
        public ProtoPackedEntity Value;
    }
}