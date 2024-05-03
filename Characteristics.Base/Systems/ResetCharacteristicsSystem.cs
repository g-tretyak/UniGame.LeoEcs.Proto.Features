namespace UniGame.Ecs.Proto.Characteristics.Base.Systems
{
    using System;
    using Aspects;
    using Components.Requests;
    using LeoEcs.Bootstrap.Runtime.Attributes;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    [Serializable]
    public class ResetCharacteristicsSystem : IProtoRunSystem
    {
        private ProtoWorld _world;

        private ProtoIt _requestFilter = It
            .Chain<ResetCharacteristicRequest>()
            .End();

        private CharacteristicsAspect _characteristicsAspect;
        private ModificationsAspect _modificationsAspect;
        
        public void Run()
        {
            foreach (var requestEntity in _requestFilter)
            {
                ref var resetRequestComponent = ref _characteristicsAspect.Reset.Get(requestEntity);
                if(!resetRequestComponent.Target.Unpack(_world,out var targetEntity)) continue;
                
                //reset base value to default
                ref var baseValuePoolComponent = ref _characteristicsAspect.BaseValue.Get(targetEntity);
                ref var defaultPoolComponent = ref _characteristicsAspect.DefaultValue.Get(targetEntity);
                ref var characteristicValueComponent = ref _characteristicsAspect.Value.Get(targetEntity);
                ref var minComponent = ref _characteristicsAspect.MinValue.Get(targetEntity);
                ref var maxComponent = ref _characteristicsAspect.MaxValue.Get(targetEntity);

                maxComponent.Value = defaultPoolComponent.MaxValue;
                minComponent.Value = defaultPoolComponent.MinValue;
                characteristicValueComponent.Value = defaultPoolComponent.Value;
                baseValuePoolComponent.Value = defaultPoolComponent.BaseValue;

                var resetModificationEntity = _world.NewEntity();
                ref var resetModificationComponent = ref _modificationsAspect.ResetModifications.Add(resetModificationEntity);
                resetModificationComponent.Characteristic = resetRequestComponent.Target;

                _characteristicsAspect.Recalculate.GetOrAddComponent(targetEntity);
            }
            
        }
    }
}