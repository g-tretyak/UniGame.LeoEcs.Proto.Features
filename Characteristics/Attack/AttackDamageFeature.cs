﻿namespace UniGame.Ecs.Proto.Characteristics.Attack
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

    [CreateAssetMenu(menuName = "Proto Features/Characteristics/Attack Damage Feature")]
    public sealed class AttackDamageFeature : CharacteristicFeature<AttackDamageEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class AttackDamageEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.AddCharacteristic<AttackDamageComponent>();
            ecsSystems.Add(new UpdateAttackDamageChangedSystem());

            return UniTask.CompletedTask;
        }
    }
}