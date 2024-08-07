namespace UniGame.Ecs.Proto.Characteristics.SplashDamage.Converters
{
	using System;
	using Base.Components.Requests;
	using Components;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Converter.Runtime;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	/// <summary>
	/// Converts splash damage data and applies it to the target game object in the ECS world.
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
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