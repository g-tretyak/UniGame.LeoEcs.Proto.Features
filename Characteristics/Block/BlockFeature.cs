namespace unigame.ecs.proto.Characteristics.Block
{
    using System;
    using Components;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using unigame.ecs.proto.Characteristics.Base;
    using unigame.ecs.proto.Characteristics.Feature;
     
    using Systems;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Characteristics/Block Feature")]
    public sealed class BlockFeature : CharacteristicFeature<BlockEcsFeature>
    {
    }
    
    [Serializable]
    public sealed class BlockEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.AddCharacteristic<BlockComponent>();
            ecsSystems.Add(new RecalculateBlockSystem());

            return UniTask.CompletedTask;
        }
    }
}