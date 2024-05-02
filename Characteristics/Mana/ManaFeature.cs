namespace UniGame.Ecs.Proto.Characteristics.Mana
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

	[CreateAssetMenu(menuName = "Proto Features/Characteristics/Mana Feature")]
	public sealed class ManaFeature : CharacteristicFeature<ManaEcsFeature>
	{
	}
	
	[Serializable]
	public class ManaEcsFeature : CharacteristicEcsFeature
	{
		protected sealed override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
		{
			ecsSystems.AddCharacteristic<ManaComponent>();
			// Recalculate max mana value. Use this request RecalculateMaxManaRequest when you want to recalculate max mana value.
			ecsSystems.Add(new RecalculateManaSystem());
			
			return UniTask.CompletedTask;
		}
	}
}