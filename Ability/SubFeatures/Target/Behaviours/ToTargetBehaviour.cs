namespace unigame.ecs.proto.Ability.SubFeatures.Target.Behaviours
{
    using System;
    using Ability.UserInput.Components;
    using Components;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsProto;
    using Selection.Components;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class ToTargetBehaviour : IAbilityBehaviour
    {
        public void Compose(ProtoWorld world, ProtoEntity abilityEntity, bool isDefault)
        {
            var selectablePool = world.GetPool<SelectableAbilityComponent>();
            selectablePool.Add(abilityEntity);

            var selectedTargetsPool = world.GetPool<SelectedTargetsComponent>();
            selectedTargetsPool.Add(abilityEntity);

            var targetablePool = world.GetPool<TargetableAbilityComponent>();
            targetablePool.Add(abilityEntity);
            
            var targetsPool = world.GetPool<AbilityTargetsComponent>();
            targetsPool.Add(abilityEntity);
            
            world.AddComponent<MultipleTargetsComponent>(abilityEntity);
            world.AddComponent<SoloTargetComponent>(abilityEntity);
            
            var upPool = world.GetPool<CanApplyWhenUpInputComponent>();
            
            if(!isDefault && !upPool.Has(abilityEntity))
            {
                upPool.Add(abilityEntity);
            }
        }
    }
}