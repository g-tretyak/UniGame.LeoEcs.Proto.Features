namespace UniGame.Ecs.Proto.GameEffects.BlockAutoAttackEffect.Systems
{
	using System;
	using Ability.Common.Components;
	using AbilityInventory.Components;
	using Game.Ecs.Time.Service;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;

	/// <summary>
	/// Remove block auto attack effect system.
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[Serializable]
	[ECSDI]
	public class RemoveBlockAutoAttackEffectSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _abilityFilter;
		private ProtoPool<AbilityPauseComponent> _pauseAbilityPool;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_abilityFilter = _world
				.Filter<AbilityPauseComponent>()
				.Inc<DefaultAbilityComponent>()
				.Exc<AbilityMetaComponent>()
				.End();
		}

		public void Run()
		{
			foreach (var abilityEntity in _abilityFilter)
			{
				ref var pauseAbilityComponent = ref _pauseAbilityPool.Get(abilityEntity);
				if (pauseAbilityComponent.Duration > GameTime.Time)
					continue;
				_pauseAbilityPool.Del(abilityEntity);
			}
		}
	}
}