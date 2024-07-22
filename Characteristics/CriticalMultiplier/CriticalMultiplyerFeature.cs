namespace UniGame.Ecs.Proto.Characteristics.CriticalMultiplier
{
    using System;
    using Components;
    using Cysharp.Threading.Tasks;
    using Base;
    using Base.Aspects;
    using Feature;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// - recalculate attack speed characteristic
    /// </summary>
    [CreateAssetMenu(menuName = "Proto Features/Characteristics/Critical Multiplier Feature",fileName = "Critical Multiplier")]
    public sealed class CriticalMultiplierFeature : CharacteristicFeature<CriticalMultiplierEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class CriticalMultiplierEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            //register health characteristic
            ecsSystems.AddCharacteristic<CriticalMultiplierComponent>();
            //update attack speed value
            ecsSystems.Add(new UpdateCriticalChanceChangedSystem());
            
            return UniTask.CompletedTask;
        }
    }
    
    /// <summary>
    /// Armor resist aspect
    /// </summary>
    [Serializable]
    public class CriticalMultiplierCharacteristicAspect : GameCharacteristicAspect<CriticalMultiplierComponent>
    {
    }
}