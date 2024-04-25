namespace Game.Code.Configuration.Runtime.Ability.Abstract
{
    using Leopotam.EcsProto;


    public interface IAbilityAdjustmentType
    {
        void Execute(IProtoSystems systems, int entity);
    }
}