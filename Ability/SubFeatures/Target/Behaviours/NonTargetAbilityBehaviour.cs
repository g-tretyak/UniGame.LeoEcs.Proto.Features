namespace unigame.ecs.proto.Ability.SubFeatures.Target.Behaviours
{
    using System;
    using Code.Configuration.Runtime.Ability.Description;
    using Components;
     
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class NonTargetAbilityBehaviour : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, int abilityEntity, bool isDefault)
        {
            world.AddComponent<NonTargetAbilityComponent>(abilityEntity);
        }
    }
}