namespace UniGame.Ecs.Proto.Characteristics.Shield
{
    using System;
    using Base.Aspects;
    using Systems;
    using Components;
    using Cysharp.Threading.Tasks;
    using Feature;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Proto Features/Characteristics/Shield Feature")]
    public sealed class ShieldFeature : CharacteristicFeature<ShieldEcsFeature> {}
    
    [Serializable]
    public sealed class ShieldEcsFeature : CharacteristicEcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new ProcessShieldSystem());
            ecsSystems.DelHere<ChangeShieldRequest>();

            ecsSystems.Add(new ResetShieldSystem());
            
            return UniTask.CompletedTask;
        }
    }
    
    [Serializable]
    public sealed class ShieldCharacteristicAspect : GameCharacteristicAspect<ShieldComponent>
    {
        //requests
        public ProtoPool<ChangeShieldRequest> ChangeShieldRequest;
    }
}