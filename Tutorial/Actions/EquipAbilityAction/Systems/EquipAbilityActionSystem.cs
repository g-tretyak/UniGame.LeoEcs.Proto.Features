namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.EquipAbilityAction.Systems
{
	using System;
	using Aspects;
	using Components;
	using Game.Ecs.Core.Components;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;

	/// <summary>
	/// Equip ability to champion.
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class EquipAbilityActionSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EquipAbilityActionAspect _aspect;
		private EcsFilter _championFilter;
		private EcsFilter _abilityActionFilter;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_championFilter = _world
				.Filter<ChampionComponent>()
				.End();
			_abilityActionFilter = _world
				.Filter<EquipAbilityActionComponent>()
				.Exc<CompletedEquipAbilityActionComponent>()
				.End();
		}

		public void Run()
		{
			if (_championFilter.First() < 0) return;
			
			var championEntity = (ProtoEntity)_championFilter.First();
			
			foreach (var equipAbilityActionEntity in _abilityActionFilter)
			{
				ref var equipAbilityActionComponent = ref _aspect.EquipAbilityAction.Get(equipAbilityActionEntity);
				
                foreach (var abilityCell in equipAbilityActionComponent.AbilityCells)
				{
					var abilityId = abilityCell.AbilityId;
					var slot = abilityCell.SlotId;
				
					var requestEntity = _world.NewEntity();
					ref var request = ref _aspect.EquipAbilityIdRequest.Add(requestEntity);
					request.AbilityId = abilityId;
					request.AbilitySlot = slot;
					request.IsUserInput = true;
					request.IsDefault = slot == 0;
					request.Owner = championEntity.PackEntity(_world);
				}
                _aspect.CompletedEquipAbilityAction.Add(equipAbilityActionEntity);
			}
		}
	}
}