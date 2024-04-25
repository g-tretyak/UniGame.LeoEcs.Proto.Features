namespace unigame.ecs.proto.Characteristics.CriticalChance
{
    using System;
    using Attack.Components;
    using Components;
    using Cysharp.Threading.Tasks;
    using unigame.ecs.proto.Characteristics.Base;
    using unigame.ecs.proto.Characteristics.Feature;
     
    using Systems;
    using UnityEngine;

    /// <summary>
    /// - recalculate attack speed characteristic
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/AttackRange Feature",fileName = "AttackRange Feature")]
    public sealed class CriticalChanceFeature : CharacteristicFeature<CriticalChanceEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class CriticalChanceEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            //register health characteristic
            ecsSystems.AddCharacteristic<AttackRangeComponent>();
            //update attack speed value
            ecsSystems.Add(new UpdateAttackRangeChangedSystem());
            
            return UniTask.CompletedTask;
        }
    }
}