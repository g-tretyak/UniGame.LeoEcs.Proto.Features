namespace unigame.ecs.proto.Effects.Systems
{
	using Aspects;
	using Components;
	using Game.Ecs.Time.Service;
	using Leopotam.EcsLite;
	using Leopotam.EcsProto;
	using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
	using UniGame.LeoEcs.Shared.Extensions;
	using UnityEngine;

	/// <summary>
	/// Delayed effect system. Trigger effect after delay
	/// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	[ECSDI]
	public class DelayedEffectSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _filter;

		private EffectAspect _effectAspect;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			_filter = _world
				.Filter<DelayedEffectComponent>()
				.Exc<EffectDurationComponent>()
				.Exc<EffectPeriodicityComponent>()
				.Exc<CompletedDelayedEffectComponent>()
				.End();
		}

		public void Run()
		{
			foreach (var entity in _filter)
			{
				ref var delayedEffect = ref _effectAspect.Delayed.Get(entity);
				var nextApplyingTime = delayedEffect.LastApplyingTime + delayedEffect.Delay;
				if(GameTime.Time < nextApplyingTime && !Mathf.Approximately(nextApplyingTime, GameTime.Time))
					continue;
				delayedEffect.Configuration.ComposeEntity(_world, entity);
				_effectAspect.CompletedDelayed.Add(entity);
			}
		}
	}
}