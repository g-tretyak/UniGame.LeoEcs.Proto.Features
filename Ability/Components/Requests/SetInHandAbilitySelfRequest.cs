namespace unigame.ecs.proto.Ability.Common.Components
{
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// Запрос "положить" в руку умение по энтити. Умение должно принадлежать этому же чемпиону.
    /// </summary>
    public struct SetInHandAbilitySelfRequest
    {
        public ProtoPackedEntity Value;
    }
}