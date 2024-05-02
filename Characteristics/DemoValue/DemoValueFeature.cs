namespace UniGame.Ecs.Proto.Characteristics.DemoValue
{
    using System;
    using Components;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.Ecs.Proto.Characteristics.Base;
    using UniGame.Ecs.Proto.Characteristics.Feature;
     
    using UnityEngine;

    /// <summary>
    /// - recalculate health characteristic
    /// - check ready to death status if health <= 0
    /// - update helath value by request
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/Demo Value Feature")]
    public sealed class DemoValueFeature : CharacteristicFeature<DemoValueEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class DemoValueEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.AddCharacteristic<DemoValueComponent>();
            
            return UniTask.CompletedTask;
        }
    }
}