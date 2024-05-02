namespace UniGame.Ecs.Proto.Characteristics.ManaRegeneration
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

	[CreateAssetMenu(menuName = "Proto Features/Characteristics/Mana Regeneration Feature")]
	public sealed class ManaRegenerationFeature : CharacteristicFeature<ManaRegenerationEcsFeature>
	{
	}
	
	[Serializable]
	public sealed class ManaRegenerationEcsFeature : CharacteristicEcsFeature
	{
		protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
		{
			ecsSystems.AddCharacteristic<ManaRegenerationComponent>();
			// Recalculate mana regeneration value. Use this request RecalculateManaRegenerationRequest when you want to recalculate mana regeneration value.
			ecsSystems.Add(new RecalculateManaRegeneration());
			// Mana regeneration. Uses request ChangeManaRequest when you want to change mana value.
			// Inside uses a timer. 
			ecsSystems.Add(new ProcessManaRegenerationSystem());
			return UniTask.CompletedTask;
		}
	}
}