namespace UniGame.Ecs.Proto.Characteristics.Mana.Converters
{
	using System;
	using Base.Components.Requests;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Converter.Runtime;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class ManaComponentConverter : LeoEcsConverter
	{
		public float maxMana;
		
		public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
		{
			ref var createCharacteristicRequest = ref world.AddComponent<CreateCharacteristicRequest<ManaComponent>>(entity);
			createCharacteristicRequest.Value = maxMana;
			createCharacteristicRequest.MaxValue = maxMana;
			createCharacteristicRequest.MinValue = 0;
			createCharacteristicRequest.Owner = entity.PackEntity(world);
            
			ref var valueComponent = ref world.AddComponent<ManaComponent>(entity);
			valueComponent.Mana = maxMana;
			valueComponent.MaxMana = maxMana;
		}
	}
}