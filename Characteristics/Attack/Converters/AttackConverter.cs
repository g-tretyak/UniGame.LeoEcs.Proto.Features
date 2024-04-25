namespace unigame.ecs.proto.Characteristics.Attack.Converters
{
    using System;
    using Base.Components.Requests;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class AttackConverter : LeoEcsConverter
    {
        [SerializeField]
        [Min(0.0f)]
        public float attackDamage = 10.0f;

        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            ref var attackDamageComponent = ref world.GetOrAddComponent<AttackDamageComponent>(entity);
            attackDamageComponent.Value = attackDamage;
            
            ref var attackDamageRequest = ref world
                .GetOrAddComponent<CreateCharacteristicRequest<AttackDamageComponent>>(entity);
            attackDamageRequest.Value = attackDamage;
            attackDamageRequest.MaxValue = float.MaxValue;
            attackDamageRequest.MinValue = 0;
            attackDamageRequest.Owner = entity.PackEntity(world);
        }
    }
}