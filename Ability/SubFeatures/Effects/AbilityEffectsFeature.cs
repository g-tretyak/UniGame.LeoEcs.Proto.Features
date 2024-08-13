namespace Game.Modules.leoecs.proto.features.Ability.SubFeatures.Effects
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.Ecs.Proto.Ability.SubFeatures;
    using UniGame.LeoEcs.Shared.Extensions;
    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class AbilityEffectsFeature : AbilitySubFeature
    {
        public override UniTask<IProtoSystems> OnInitializeSystems(IProtoSystems ecsSystems)
        {
            return base.OnInitializeSystems(ecsSystems);
        }

        public override UniTask<IProtoSystems> OnApplyEffectsSystems(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ApplyAbilityEffectsSystem());
            
            return base.OnInitializeSystems(ecsSystems);
        }
    }
}