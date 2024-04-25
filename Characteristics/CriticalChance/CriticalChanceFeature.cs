namespace unigame.ecs.proto.Characteristics.CriticalChance
{
    using System;
    using Base;
    using Components;
    using Cysharp.Threading.Tasks;
    using Feature;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// - recalculate attack speed characteristic
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/Critical Chance Feature",fileName = "Critical Chance")]
    public sealed class CriticalChanceFeature : CharacteristicFeature<CriticalChanceEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class CriticalChanceEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            //register health characteristic
            ecsSystems.AddCharacteristic<CriticalChanceComponent>();
            //update attack speed value
            ecsSystems.Add(new UpdateCriticalChanceChangedSystem());
            
            return UniTask.CompletedTask;
        }
    }
}