namespace unigame.ecs.proto.Characteristics.AttackSpeed
{
    using System;
    using Components;
    using Cysharp.Threading.Tasks;
    using unigame.ecs.proto.Characteristics.Base;
    using unigame.ecs.proto.Characteristics.Feature;
     
    using Systems;
    using UnityEngine;

    /// <summary>
    /// - recalculate attack speed characteristic
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/AttackSpeed Feature")]
    public sealed class AttackSpeedFeature : CharacteristicFeature<AttackSpeedEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class AttackSpeedEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            //register health characteristic
            ecsSystems.AddCharacteristic<AttackSpeedComponent>();
            //update attack speed value
            ecsSystems.Add(new UpdateAttackSpeedChangedSystem());

            return UniTask.CompletedTask;
        }
    }
}