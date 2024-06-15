
using Game.Code.Services.Animation;
using Game.Ecs.Animation.AnimationCore.Components.Requests;
using Game.Ecs.Animation.AnimationCore.Systems;
using Leopotam.EcsProto.QoL;
using UniGame.Context.Runtime.Extension;
using UniGame.Core.Runtime;
using UniGame.LeoEcs.Shared.Extensions;
using UnityEngine;

namespace Game.Ecs.GameLogic.MovementFeature
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime;

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
    [CreateAssetMenu(menuName = "Gameplay/Features/AnimationCore Feature", fileName = " Animation Core Feature")]
    public class AnimationCoreFeature : BaseLeoEcsFeature
    {
        public override async UniTask InitializeAsync(IProtoSystems ecsSystems)
        {
            var context = ecsSystems.GetShared<IContext>();
            IAnimationService animationService = await context.ReceiveFirstAsync<IAnimationService>(); 
           
            ecsSystems.Add(new PlayAnimationSystem(animationService));
            ecsSystems.DelHere<PlayAnimationWithActorRequest>();
        }
    }
}