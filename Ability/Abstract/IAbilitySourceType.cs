namespace Game.Code.Configuration.Runtime.Ability.Abstract
{
    using Leopotam.EcsProto;


    public interface IAbilitySourceType
    {
        void Execute(IProtoSystems systems, int entity);
    }
}