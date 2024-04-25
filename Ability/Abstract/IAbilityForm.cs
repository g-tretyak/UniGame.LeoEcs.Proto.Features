namespace Game.Code.Configuration.Runtime.Ability.Abstract
{
    using Leopotam.EcsProto;


    public interface IAbilityForm
    {
        void Execute(IProtoSystems systems, int entity);
    }
}