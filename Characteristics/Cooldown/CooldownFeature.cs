namespace unigame.ecs.proto.Characteristics.Cooldown
{
    using System;
    using Systems;
    using Components;
    using Cysharp.Threading.Tasks;
    using Feature;
     
    using Leopotam.EcsLite.ExtendedSystems;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/Cooldown Feature")]
    public sealed class CooldownFeature : CharacteristicFeature<CooldownEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class CooldownEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new RecalculateCooldownSystem());
            ecsSystems.DelHere<RecalculateCooldownSelfRequest>();
            ecsSystems.Add(new ResetCooldownSystem());
            
            return UniTask.CompletedTask;
        }
    }
}