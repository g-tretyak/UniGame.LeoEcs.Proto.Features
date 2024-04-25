namespace unigame.ecs.proto.Characteristics.ManaRegeneration.Systems
{
	using Base.Components.Requests.OwnerRequests;
	using Components;
	 
	using Mana.Components;
	using Time.Service;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
#endif
	

	/// <summary>
	/// Regenerate mana.
	/// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
	[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
	[Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
	public class ProcessManaRegenerationSystem : IProtoInitSystem, IProtoRunSystem
	{
		private ProtoWorld _world;
		private EcsFilter _filter;
		private ProtoPool<ManaRegenerationComponent> _manaRegenerationPool;
		private ProtoPool<ManaRegenerationTimerComponent> _manaRegenerationTimerPool;
		private ProtoPool<ManaComponent> _manaPool;
		private ProtoPool<ChangeCharacteristicBaseRequest<ManaComponent>> _manaChangePool;

		public void Init(IProtoSystems systems)
		{
			_world = systems.GetWorld();
			
			_filter = _world.Filter<ManaRegenerationComponent>()
				.Inc<ManaRegenerationTimerComponent>()
				.Inc<ManaComponent>()
				.End();
			
			_manaRegenerationPool = _world.GetPool<ManaRegenerationComponent>();
			_manaRegenerationTimerPool = _world.GetPool<ManaRegenerationTimerComponent>();
			_manaChangePool = _world.GetPool<ChangeCharacteristicBaseRequest<ManaComponent>>();
		}

		public void Run()
		{
			foreach (var entity in _filter)
			{
				ref var manaRegenerationComponent = ref _manaRegenerationPool.Get(entity);
				ref var manaRegenerationTimerComponent = ref _manaRegenerationTimerPool.Get(entity);
				
				if (GameTime.Time < manaRegenerationTimerComponent.LastTickTime)
					continue;
				
				var manaRegeneration = manaRegenerationComponent.Value * manaRegenerationTimerComponent.TickTime;
				manaRegenerationTimerComponent.LastTickTime = GameTime.Time + manaRegenerationTimerComponent.TickTime;
				
				var requestEntity = _world.NewEntity();
				ref var request = ref _manaChangePool.Add(requestEntity);
				
				request.Value = manaRegeneration;
				request.Source = _world.PackEntity(entity);
				request.Target = _world.PackEntity(entity);
			}
		}
	}
}