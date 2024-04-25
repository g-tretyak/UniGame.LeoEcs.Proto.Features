namespace unigame.ecs.proto.Ability.SubFeatures.CriticalAnimations.Abstract
{
     

    public interface IAbilityAnimationBehavior
    {
        public void Compose(ProtoWorld world, int abilityEntity, bool isDefault);
    }
}