using Game.Ecs.Audio.AudioCore.Components.Requests;
using Game.Ecs.Audio.AudioCore.Systems;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UniGame.Context.Runtime.Extension;
using UniGame.LeoEcs.Bootstrap.Runtime;
using UniGame.LeoEcs.Shared.Extensions;

namespace Game.Ecs.Audio.AudioCore
{
    using Cysharp.Threading.Tasks;
    using UniGame.Core.Runtime;
    using UniGame.Core.Runtime.Extension;
    using UnityEngine;

    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Features/Audio/AudioCoreFeature", fileName = "AudioCoreFeature")]
    public class AudioCoreFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new InstantiateAudioListenerSystem());
            ecsSystems.Add(new UpdateAudioListenerPositionSystem());
            
            ecsSystems.Add(new StopRequestedContinuousEventSystem());

            ecsSystems.Add(new CullPlaybacksSystem());
            
            ecsSystems.DelHere<StopFMODEventRequest>();
            
            return UniTask.CompletedTask;
        }

        
    }
}