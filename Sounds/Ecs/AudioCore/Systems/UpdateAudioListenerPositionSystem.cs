using Game.Ecs.Audio.AudioCore.Aspects;
using Game.Ecs.Audio.AudioCore.Components;
using Leopotam.EcsProto;
using UniGame.LeoEcs.Shared.Extensions;

namespace Game.Ecs.Audio.AudioCore.Systems
{
    using System;
    using System.Linq;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

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
    [ECSDI]
    public class UpdateAudioListenerPositionSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _audioListenerRootFilter;
        private EcsFilter _audioListenerTransformFilter;
        
        public AudioCoreAspect _audioCoreAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
              
            _audioListenerRootFilter = _world
                .Filter<AudioListenerRootComponent>()
                .End();

            _audioListenerTransformFilter = _world
                .Filter<AudioListenerTransformComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var audioListenerEntity in _audioListenerRootFilter)
            {
                ref var audioListenerRoot = ref _audioCoreAspect.AudioListenerRoot.Get(audioListenerEntity);
                var audioListenerRootTransform = audioListenerRoot.Root;
                
                foreach(var audioListenerTransformEntity in _audioListenerTransformFilter)
                {
                    ref var audioListenerTransform = ref _audioCoreAspect.AudioListenerTransform.Get(audioListenerTransformEntity);
                    audioListenerTransform.Transform.position = audioListenerRootTransform.position;
                }
            }
        }
    }
}