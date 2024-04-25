namespace unigame.ecs.proto.Characteristics.SplashDamage.Converters
{
	using System;
	using Base.Components.Requests;
	using Components;
	 
	using UniGame.LeoEcs.Converter.Runtime;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	[Serializable]
	public class SplashDamageConverter : LeoEcsConverter
	{
		public float _splashDamage;
		
		public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
		{
			ref var splashDamageComponent = ref world.GetOrAddComponent<SplashDamageComponent>(entity);
			splashDamageComponent.Value = _splashDamage;
            
			ref var createCharacteristicRequest = ref world.GetOrAddComponent<CreateCharacteristicRequest<SplashDamageComponent>>(entity);
			createCharacteristicRequest.Value = _splashDamage;
			createCharacteristicRequest.MaxValue = 1000;
			createCharacteristicRequest.MinValue = 0;
			createCharacteristicRequest.Owner = world.PackEntity(entity);
		}
	}
}