namespace Game.Code.Configuration.Runtime.Ability.Description
{
    using Leopotam.EcsProto;


    public interface IAbilityBehaviour
    {
        void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault);
    }
}