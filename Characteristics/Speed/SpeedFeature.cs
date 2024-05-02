﻿namespace UniGame.Ecs.Proto.Characteristics.Speed
{
    using System;
    using Base;
    using Systems;
    using Components;
    using Cysharp.Threading.Tasks;
    using Feature;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Proto Features/Characteristics/Speed Feature")]
    public class SpeedFeature : CharacteristicFeature<SpeedEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class SpeedEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.AddCharacteristic<SpeedComponent>();
            ecsSystems.Add(new RecalculateSpeedSystem());
            
            return UniTask.CompletedTask;
        }
    }
}