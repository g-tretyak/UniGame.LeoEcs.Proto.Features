namespace UniGame.Ecs.Proto.Effects
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Components;
    using Game.Code.Configuration.Runtime.Effects;
    using Game.Code.Configuration.Runtime.Effects.Abstract;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public static class EffectsExtensions
    {
#if ENABLE_IL2CPP
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void CreateRequests(this List<IEffectConfiguration> effects, 
            ProtoWorld world, 
            ProtoPackedEntity source,
            ProtoPackedEntity destination)
        {
            if(effects == null) return;
            
            foreach (var effect in effects)
                effect.CreateRequest(world,ref source,ref destination);
        }

#if ENABLE_IL2CPP
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static ProtoEntity CreateRequest(this IEffectConfiguration effect,
            ProtoWorld world,
            ref ProtoPackedEntity source,
            ref ProtoPackedEntity destination)
        {
            var requestPool = world.GetPool<CreateEffectSelfRequest>();
            var effectsEntity = world.NewEntity();
                
            ref var request = ref requestPool.Add(effectsEntity);
            request.Source = source;
            request.Destination = effect.TargetType == TargetType.Self ? source : destination;
            request.Effect = effect;
            return effectsEntity;
        }
    }
}