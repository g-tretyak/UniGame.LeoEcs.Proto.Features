namespace unigame.ecs.proto.Characteristics.SplashDamage
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
    /// allows you to deal damage on the area with default attacks, 
    /// the characteristic increases the damage that opponents receive near the main target
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/SplashDamage Feature")]
    public sealed class SplashDamageFeature : CharacteristicFeature<SplashDamageEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class SplashDamageEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.AddCharacteristic<SplashDamageComponent>();
            // update Splash Damage value
            ecsSystems.Add(new RecalculateSplashDamageSystem());

            return UniTask.CompletedTask;
        }
    }
}