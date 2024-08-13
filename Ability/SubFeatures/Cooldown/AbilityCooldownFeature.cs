﻿namespace UniGame.Ecs.Proto.Ability.SubFeatures.Cooldown
{
    using System;
    using Cysharp.Threading.Tasks;
    using LeoEcs.Shared.Extensions;
    using Leopotam.EcsProto;
    using Systems;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class AbilityCooldownFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnInitializeSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new AbilityCompleteCooldownSystem());
            return base.OnInitializeSystems(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnEvaluateAbilitySystem(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new AbilityRestartCooldownSystem());
            return base.OnEvaluateAbilitySystem(ecsSystems);
        }
    }
}