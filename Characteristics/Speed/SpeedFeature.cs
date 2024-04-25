namespace unigame.ecs.proto.Characteristics.Speed
{
    using System;
    using Base;
    using Systems;
    using Components;
    using Cysharp.Threading.Tasks;
    using Feature;
     
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/Speed Feature")]
    public class SpeedFeature : CharacteristicFeature<SpeedEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class SpeedEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.AddCharacteristic<SpeedComponent>();
            ecsSystems.Add(new RecalculateSpeedSystem());
            
            return UniTask.CompletedTask;
        }
    }
}