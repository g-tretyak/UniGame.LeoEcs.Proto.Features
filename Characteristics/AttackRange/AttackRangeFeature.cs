namespace unigame.ecs.proto.Characteristics.CriticalChance
{
    using System;
    using Components;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Base;
    using Feature;
     
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;
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