namespace UniGame.Ecs.Proto.Characteristics.Dodge
{
    using System;
    using Base;
    using Base.Aspects;
    using Components;
    using Cysharp.Threading.Tasks;
    using Feature;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Proto Features/Characteristics/Dodge Feature")]
    public sealed class DodgeFeature : CharacteristicFeature<DodgeEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class DodgeEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.AddCharacteristic<DodgeComponent>();
            ecsSystems.Add(new RecalculateDodgeSystem());

            return UniTask.CompletedTask;
        }
    }
    
    /// <summary>
    /// Armor resist aspect
    /// </summary>
    [Serializable]
    public class DodgeCharacteristicAspect : GameCharacteristicAspect<DodgeComponent>
    {
    }

}