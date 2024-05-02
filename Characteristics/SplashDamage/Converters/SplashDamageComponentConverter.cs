namespace UniGame.Ecs.Proto.Characteristics.SplashDamage.Converters
{
	using System;
	using Base.Components.Requests;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Converter.Runtime;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class SplashDamageConverter : LeoEcsConverter
	{
		public float splashDamage;
		
		public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
		{
			ref var splashDamageComponent = ref world.GetOrAddComponent<SplashDamageComponent>(entity);
			splashDamageComponent.Value = splashDamage;
            
			ref var createCharacteristicRequest = ref world.GetOrAddComponent<CreateCharacteristicRequest<SplashDamageComponent>>(entity);
			createCharacteristicRequest.Value = splashDamage;
			createCharacteristicRequest.MaxValue = 1000;
			createCharacteristicRequest.MinValue = 0;
			createCharacteristicRequest.Owner = entity.PackEntity(world);
		}
	}
}