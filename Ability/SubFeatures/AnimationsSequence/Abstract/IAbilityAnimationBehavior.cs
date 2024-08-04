namespace UniGame.Ecs.Proto.Ability.SubFeatures.CriticalAnimations.Abstract
{
    using Leopotam.EcsProto;


    public interface IAbilityAnimationBehavior
    {
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity);
    }
}