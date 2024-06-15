using Animancer;
using Game.Code.Services.Animation.Data.AnimacerActorList;
using Game.Ecs.Animation.AnimationCore.Components;
using Leopotam.EcsProto;

namespace Game.Ecs.Animation.AnimationCore.Converters
{
    using System;
    using System.Threading;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// 
    /// </summary>

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif

    [Serializable]
    public class AnimancerComponentConverter : LeoEcsConverter
    {
        [SerializeField]
        private AnimancerActorTypeId _actorType;

        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var animancerComponent = target.GetComponent<Animancer.AnimancerComponent>();
            if (animancerComponent == null)
            {
                Debug.LogError($"AnimancerComponent not found on {target.name}");
                return;
            }

            ref var animancerAnimatorComponent = ref world.AddComponent<AnimancerAnimatorComponent>(entity);
            animancerAnimatorComponent.AnimancerComponent = animancerComponent;
            animancerAnimatorComponent.ActorType = _actorType;
        }
    }
}