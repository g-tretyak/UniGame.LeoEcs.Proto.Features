namespace unigame.ecs.proto.Characteristics.ArmorResist.Converters
{
	using System;
	using System.Threading;
	using Base.Components.Requests;
	using Components;
	using Leopotam.EcsProto;
	using Sirenix.OdinInspector;
	using UniGame.LeoEcs.Converter.Runtime;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;
	using UnityEngine.Serialization;

	[Serializable]
	public class ArmorResistConverter : LeoEcsConverter
	{
		#region Inspector
		
		public float physicalResist;
		[MaxValue(100)]
		public float maxValue = 100f;
		[MinValue(0)]
		public float minValue = 0f;

		#endregion
		
		public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
		{
			ref var createCharacteristicRequest = ref world.AddComponent<CreateCharacteristicRequest<ArmorResistComponent>>(entity);
			createCharacteristicRequest.Value = physicalResist;
			createCharacteristicRequest.MaxValue = maxValue;
			createCharacteristicRequest.MinValue = minValue;
			createCharacteristicRequest.Owner = entity.PackEntity(world);
            
			ref var valueComponent = ref world.AddComponent<ArmorResistComponent>(entity);
			valueComponent.Value = physicalResist;
		}
	}
}