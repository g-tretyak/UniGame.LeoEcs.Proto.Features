namespace UniGame.Ecs.Proto.Characteristics.Duration
{
    using System;
    using Systems;
    using Components;
    using Cysharp.Threading.Tasks;
    using Feature;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/Duration Feature")]
    public sealed class DurationFeature : CharacteristicFeature<DurationEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class DurationEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new RecalculateDurationSystem());
            ecsSystems.DelHere<RecalculateDurationRequest>();

            ecsSystems.Add(new ResetDurationSystem());
            
            return UniTask.CompletedTask;
        }
    }
}