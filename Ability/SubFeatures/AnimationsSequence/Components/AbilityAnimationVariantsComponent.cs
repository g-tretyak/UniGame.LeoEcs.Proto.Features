namespace unigame.ecs.proto.Ability.SubFeatures.CriticalAnimations.Components
{
    using System;
    using System.Collections.Generic;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;


    /// <summary>
    /// list of animation variants
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct AbilityAnimationVariantsComponent : IProtoAutoReset<AbilityAnimationVariantsComponent>
    {
        public List<ProtoPackedEntity> Variants;
        
        public void AutoReset(ref AbilityAnimationVariantsComponent c)
        {
            c.Variants ??= new List<ProtoPackedEntity>();
            c.Variants.Clear();
        }
    }
}